using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public PlayerController playerController;
    public GameObject pauseMenuUI;
    public GameObject pauseFirstButton;

    public WaveSpawner waveSpawner;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        //So that the player cant pause after death
        if(playerController.currentHealth > 0 && waveSpawner.wavesComplete != 21)
        {
            //If start button or escape pressed
            if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
            {
                if(isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }   
    }

    public void Resume()
    {
        //Take away UI and set time back to normal
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        //Add UI and set time to stopped
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }

    public void LoadMenu()
    {
        //When you return to menu reset paused time
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Resume();
    }

    public void Quit()
    {
        //Quit
        Application.Quit();
    }
}
