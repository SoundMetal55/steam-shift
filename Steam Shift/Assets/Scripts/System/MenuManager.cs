using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject helpMenuUI;
    public GameObject levelSelectMenuUI;

    public string startScene = "MainMenu";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseManager.GameIsPaused)
            {
                PauseManager.Unpause();
                pauseMenuUI.SetActive(false);
            }
            else
            {
                PauseManager.Pause();
                pauseMenuUI.SetActive(true);
            }
        }
    }

    // pause menu
    public void OpenPauseMenu()
    {
        PauseManager.Pause();
        pauseMenuUI.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        PauseManager.Unpause();
        pauseMenuUI.SetActive(false);
    }

    // help menu
    public void OpenHelpMenu()
    {
        helpMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void CloseHelpMenu()
    {
        helpMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    // level select menu
    public void OpenLevelSelectMenu()
    {
        levelSelectMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void CloseLevelSelectMenu()
    {
        levelSelectMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        PauseManager.Unpause();
        pauseMenuUI.SetActive(false);
        SceneManager.LoadScene(startScene);
    }

    // main menu
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

