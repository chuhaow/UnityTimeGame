//------------------------------------------------------
// Author: Chu Hao Wen
//
// PURPOSE:    Used control the Menus
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InGameMenus : MonoBehaviour
{
    public GameObject NextLevelScreen;
    public GameObject EndScreen;
    public GameObject PauseMenu;
    public GameObject OptionsMenu;
    public GameObject MainMenu;
    public bool isPaused;
    #region Singleton
    public static InGameMenus instance;
    //public TimestopVFXController VFX;

    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }

    }
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //Pause if we hit esc
        {
            switch (isPaused)
            {
                case true:
                    disablePauseMenu();
                    break;
                case false:
                    enablePauseMenu();
                    break;
            }
            
        }
    }

    public void NextLevel() // Move to next stage
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 <= 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            NextLevelScreen.SetActive(false);
        }

    }

    public void enableNextLevelScreen() // The next stage screen for when you react the end of a stage
    {
        NextLevelScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void enableEndScreen()   // Screen for if you reach the last stage
    {
        EndScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void enablePauseMenu()   // In game pause menu
    {
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
        isPaused = true;
        PauseMenu.SetActive(true);
    }

    public void disablePauseMenu()  // stop of the pause
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        isPaused = false;
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    }

    public void EnableMainMenu()    // Goto the main menu
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        isPaused = false;
        EndScreen.SetActive(false);
    }

    public void Play()  // Play button
    {
        SceneManager.LoadScene(1);
        MainMenu.SetActive(false);
    }

    public void QuitGame()  // Quit button
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
