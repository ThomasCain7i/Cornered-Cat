using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu, controlsMenu, difficultyMenu;
    public GameObject menuFirstButton, controlsFirstButton, controlsCloseButton, playFirstButton, playCloseButton;

    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(menuFirstButton);
    }

    public void PlayGameEasy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }    
    
    public void PlayGameNormal()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }    
    
    public void PlayGameHard()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void OpenControls()
    {
        //Set control menu to true, main menu to false and current button to back
        controlsMenu.SetActive(true);
        mainMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controlsFirstButton);
    }

    public void CloseControls()
    {
        //Set control menu to false, main menu to true and current button to play
        controlsMenu.SetActive(false);
        mainMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(menuFirstButton);
    }

    public void OpenDifficulty()
    {
        //Set main menu to false, play menu to true and current button to easy
        mainMenu.SetActive(false);
        difficultyMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(playFirstButton);
    }

    public void CloseDifficulty()
    {
        mainMenu.SetActive(true);
        difficultyMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(menuFirstButton);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
