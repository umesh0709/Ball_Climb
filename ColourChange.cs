using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColourChange : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Color startColor = Color.blue;
    [SerializeField] Color endColor = Color.red;
    [SerializeField] float speed = 50f;
    Renderer rend;
    [SerializeField] float startTime;
    [SerializeField] bool isRepeatable = true;

    private void Start()
    {
        startTime = Time.time;
        rend = GetComponent<Renderer>();

    }
    private void Update()
    {
        ColorSwap();
        ColorChange();
    }

    private void ColorSwap()
    {
        if (!isRepeatable)
        {
            float t = (Time.time - startTime) * speed;
            rend.material.color = Color.Lerp(startColor, endColor, t);
        }
        else
        {
            float t = (Mathf.Cos(Time.time - startTime) * speed);
            rend.material.color = Color.Lerp(startColor, endColor, t);
        }
    }

    private  void ColorChange()
    {
        if (rend.material.color == Color.red)
        {
            gameObject.tag = "Enemy";
            
        }
        else
        {
            gameObject.tag = "Log";
            
        }
    }
   
}
