using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] GameObject heart1, heart2, heart3;
    public static int health;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        heart1.gameObject.SetActive(true);
        heart1.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);

        rb = GetComponent<Rigidbody>();
        GetComponent<SphereCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        HealthCount();
    }

    private void HealthCount()
    {
        if (health > 3)
        {
            health = 3;
        }

        switch (health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;

            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;

            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;

            case 0:

                break;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeathGround")
        {
            health--;
        }
    }
}
