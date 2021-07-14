using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkyChange : MonoBehaviour
{
    public Material[] skybox = new Material[4];
    
    
    
    
    // Start is called before the first frame update

     
    
    void Start()
    {
        RenderSky();
        RandomSkybox();
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void RenderSky()
    {
       
    }

    private void RandomSkybox()
    {
        if (MainMenu.skychangeEnable)
        {
            int index = Random.Range(0, 4);
            print(skybox.Length);
            RenderSettings.skybox = skybox[index];
            
            print("Random Skybox");
        }
        else
        {
            RenderSettings.skybox = skybox[1];
            print("Default Skybox");
        }
    }
}
