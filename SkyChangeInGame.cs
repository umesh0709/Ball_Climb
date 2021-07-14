using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyChangeInGame : MonoBehaviour
{
    SkyChange sky;
    public Material renderSkyInGame;
        
    // Start is called before the first frame update
    void Start()
    {
        renderSkyInGame = RenderSettings.skybox;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
}
