using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //Movement
    public float moveSpeed;
    public Rigidbody2D rb;

    //Reference to weapon
    public Weapon weapon;

    //Where is the mouse
    private Vector2 moveDirection;
    private Vector2 mousePosition;

    public Camera sceneCamera;

    //Health
    public int maxHealth = 5;
    public int currentHealth;

    //Invincibility after damage
    float invincibeTimer;
    bool invincible = false;

    //Change colour after damage
    Material mWhite;
    Material mDefault;
    SpriteRenderer sRend;

    //HealthBar & DeathMenu
    public HealthBar healthBar;
    public static event Action OnPlayerDeath;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        sRend = GetComponent<SpriteRenderer>();
        mDefault = sRend.material;
        mWhite = Resources.Load("mWhite", typeof(Material)) as Material;
    }
    // Update is called once per frame
    void Update()
    {
        invincibeTimer -= Time.deltaTime;

        if(invincibeTimer <= 0)
        {
            invincible = false;
        }
        //Processing Inputs
        ProcessInputs();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        FindObjectOfType<AudioManager>().Play("PlayerHurt");

        StartCoroutine("Flash");
        InvinciblePeriod();

        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Time.timeScale = 0;
            OnPlayerDeath?.Invoke();
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
        }
    }

    void InvinciblePeriod()
    {
        invincibeTimer = 1;
        if(invincibeTimer > 0)
        {
            invincible = true;
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
        //Movement horizontal and vertical
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
            FindObjectOfType<AudioManager>().Play("PlayerFire");
        }

        //Get postion of mouse relitive to camera location and dont move super fast when travelling diagonally
        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
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