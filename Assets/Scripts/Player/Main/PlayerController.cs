using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public GameObject FirePoint;

    //Movement
    public float moveSpeed;
    public Rigidbody2D rb;

    //Controller Input System
    PlayerInputActions inputActions;

    Vector2 movementInput;
    Vector2 lookPosition;

    //Reference to weapon
    public ObjectPool weapon;

    //Where is the mouse
    private Vector2 moveDirection;
    private Vector2 mousePosition;

    public Camera sceneCamera;

    //Health
    public int maxHealth = 5;
    public int currentHealth;

    //Invincibility after damage
    private bool isInvincible = false;

    [SerializeField]
    private float invincibilityDurationSeconds = 1.5f;

    //Change colour after damage
    Material mWhite;
    Material mDefault;
    SpriteRenderer sRend;

    //HealthBar & DeathMenu
    public HealthBar healthBar;
    public static event Action OnPlayerDeath;

    //Joystick controls
    public bool useController;

    //Spider
    public float webCooldown;

    //InfectedMouse
    public float infectedCooldown;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        inputActions.PlayerControls.LookDirection.performed += ctx => lookPosition = ctx.ReadValue<Vector2>();
    }
    private void Start()
    {
        //Current health = MaxHealth
        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);

        sRend = GetComponent<SpriteRenderer>();
        mDefault = sRend.material;
        mWhite = Resources.Load("mWhite", typeof(Material)) as Material;
    }
    // Update is called once per frame
    void Update()
    {

        //Processing Inputs from player
        ProcessInputs();

        //Spider web side effects
        if (webCooldown > 0)
        {
            moveSpeed = 4f;
            webCooldown -= Time.deltaTime;
        }
        else
        {
            moveSpeed = 8f;
        }

        //Infected mouse side effects
        if(infectedCooldown > 0)
        {
            moveSpeed = 0f;
            infectedCooldown -= Time.deltaTime;
        }
        else
        {
            moveSpeed = 8f;
        }
    }

    public void TakeDamage(int amount)
    {
        //If invincible do not deal damage
        if (isInvincible) return;

        //Current health - amount = damage
        currentHealth -= amount;

        //Play audio for damage taken
        FindObjectOfType<AudioManager>().Play("PlayerHurt");

        StartCoroutine("Flash");

        //Set up for healthbar UI
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Time.timeScale = 0;
            OnPlayerDeath?.Invoke();
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
        }
        StartCoroutine(BecomeTemporarilyInvincible());
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("Player turned invincible!");
        isInvincible = true;

        yield return new WaitForSeconds(invincibilityDurationSeconds);

        isInvincible = false;
        Debug.Log("Player is no longer invincible!");
    }

    void MethodThatTriggersInvulnerability()
    {
        if (!isInvincible)
        {
            StartCoroutine(BecomeTemporarilyInvincible());
        }
    }

    IEnumerator Flash()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.25f);
            sRend.material = mWhite;
            Invoke("ResetMaterial", 0.15f);
        }
    }

    void ResetMaterial()
    {
        //Change material to default
        sRend.material = mDefault;
    }
    void FixedUpdate()
    {
        // Physics Calculations
        Move();
    }

    void ProcessInputs()
    {
        if (!PauseMenu.isPaused)
        {
            Vector2 input = lookPosition;

            if (!useController)
            {
                //Movement horizontal and vertical
                float moveX = movementInput.x;
                float moveY = movementInput.y;

                //If press mouse 1 fire
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
                    if(bullet != null)
                    {
                        bullet.transform.position = FirePoint.transform.position;
                        bullet.transform.rotation = FirePoint.transform.rotation;
                        bullet.SetActive(true);
                    }
                    FindObjectOfType<AudioManager>().Play("PlayerFire");
                }

                //Get postion of mouse relitive to camera location and dont move super fast when travelling diagonally
                moveDirection = new Vector2(moveX, moveY).normalized;
                mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
            }

            if (useController)
            {

                if (Input.GetKeyDown(KeyCode.Joystick1Button2))
                {
                    GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
                    if (bullet != null)
                    {
                        bullet.transform.position = FirePoint.transform.position;
                        bullet.transform.rotation = FirePoint.transform.rotation;
                        bullet.SetActive(true);
                    }
                    FindObjectOfType<AudioManager>().Play("PlayerFire");
                }
            }
        }
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        //Turn character towards mouse location using maths
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
}