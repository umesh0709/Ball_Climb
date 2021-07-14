using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsUI;
    [SerializeField] GameObject mainMenuUI;
    public static bool skychangeEnable = true;
    SkyChange sky;
    UpwardMovement diff;
    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        sky = GetComponent<SkyChange>();
        settingsUI.SetActive(false);
        mainMenuUI.SetActive(true);
       
    }
    private void Update()
    {
       
    }

    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        print("QUIT!!");
        Application.Quit();
    }
    public void Settings()
    {
        settingsUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }
    public void Difficulty(int dif)
    {
        if (dif == 0)
        {
            UpwardMovement.speed = 0.2f;
            print("half speed");
        }
        if (dif == 1)
        {
            UpwardMovement.speed = 0.5f;
            print("normal speed");
        }
    }
    public void ChangeSkySettings(int val)
    {
        if (val == 0)
        {
             
            skychangeEnable = true;
        }
        if (val == 1)
        {
            skychangeEnable =false;
        }
    }
   
    public void SettingsBack()
    {
        settingsUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

   
}
