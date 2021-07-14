using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Pause : MonoBehaviour
{
    private static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    private static int healthRem;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        healthRem = player.health;
        gameOverUI.SetActive(false);
    }
    private void Update()
    {
        if (player.health < 1)
        {
            print("Gameover!!");
            GameOver();
        }
       
    }
    public void PauseGame()
    {
        print("pause");

        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            PauseMenu();
        }
    }

   

   public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void PauseMenu ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();      
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        print("Quit!!");
        Application.Quit();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
                         
    }

    public void WatchAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
           
            Debug.Log("ADS Ready");
        }
        else
        {
            Debug.Log("Ads Not Ready");
        }
    }
   
    public void Health()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show("rewardedVideo");
            Debug.Log("Ad shown");
            healthRem = player.health = 3;
            Time.timeScale = 1f;
            gameOverUI.SetActive(false);

        }

    }

}
