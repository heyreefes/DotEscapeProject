using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameIsPaused = false;
    bool gameOver = false;
    [SerializeField] private GameObject retryPanel;
    [SerializeField] private GameObject pausePanel;


    private void Awake()
    {
        instance = this;
        Time.timeScale = 1;

    }


    private void Update()
    {
        PauseGame();
    }

    public void ActiveMode()
    {
        gameOver = true;
        retryPanel.SetActive(true);
    }

    public void Restart()//
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOver = false;
    }

    public void PauseGame()//pausement, reset time and stop time, activate and deactivate pasuemenu panel using escape/back btn
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOver)
        {
            if (!gameIsPaused)
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
                gameIsPaused = true;
            }
            else
            {
                Time.timeScale = 1;
                pausePanel.SetActive(false);
                gameIsPaused = false;
            }
        }
    }

    public void resumeButton()//restart time after resume
    {
        Time.timeScale = 1;

    }

    public void MainMenu()
    {
        gameOver = false;
    }



}
