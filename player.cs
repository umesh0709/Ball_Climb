using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Advertisements;

[DisallowMultipleComponent]
public class player : MonoBehaviour
{
    [Header("General")]
    [SerializeField] Rigidbody rb;
    SphereCollider trigger;
     Vector3 checkPoint;
    [SerializeField] float levelLoadDelay = 0.5f;
    
    public static int health;
    static int doubleJump;

    [SerializeField] Transform deathCollider;
    [SerializeField] Vector3 offset;
   
    bool isGrounded;
    bool isControlEnable = true;
    bool collisionDisable = false;
    bool isTriggerDisable = false;

    Joystick left;
    GameObject[] logs;

    [Header("Movement Force")]
    [SerializeField] float sideForce = 5f;
    [SerializeField] float upwardForce = 5f;

    float xMove, yMove, xOffset, newPos;
    float dirX, xPos;

    string gameID = "3944985";
    bool testMode = true;
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameID, testMode);
        rb = GetComponent<Rigidbody>();
        trigger = GetComponent<SphereCollider>();
        
        health = 3;
        doubleJump = 0;
        logs = GameObject.FindGameObjectsWithTag("Log");
    }

    // Update is called once per frame
    void Update()
    {
        print(health);


        if (isControlEnable)

        {

            sideMovement();
            
        }
        if (Debug.isDebugBuild)
        {
            RespondToDebugKeys();
        }

        HealthCount();

        
        
          
        
    }

    private void HealthCount()
    {
        if (health > 3)
        {
            health = 3;
            print("Lives Full!!");
        }
        
        
    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

            collisionDisable = true;
        }
    }

    private void UpwardMovement()
    {

        if (!isGrounded)
        {
            return;
        }

        jump();

    }

    public void jump()
    {
            if ((isControlEnable) && (isGrounded))  

            rb.AddForce(Vector3.up * upwardForce, ForceMode.VelocityChange);
            print("jump");
    }

    private void sideMovement()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * sideForce * Time.deltaTime;
        xPos = transform.localPosition.x + dirX;
        transform.localPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);
    }



    private void OnCollisionEnter(Collision collision)
    {

        isGrounded = true;
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collisionDisable)
        {
            return;
        }
        isGrounded = true;
        if (collision.gameObject.tag == "Enemy")
        {
            
            print(collision.gameObject.tag);
            DeathSequence();

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collisionDisable)
        {
            return;
        }
        
        switch (other.gameObject.tag)

        {
            case "Checkpoint":
                checkPoint = other.transform.position;
                
                break;

            case "Collectible":
                health++;
                Destroy(other.gameObject);                
            break;

            case "Log":
              
                break;

            case "DoubleJump":
                
                Destroy(other.gameObject);               
                               
                break;

            case "CheckpointCollider":
                
                break;

            case "DeathGround":
                foreach (GameObject log in logs)
                {

                    log.transform.rotation = Quaternion.identity;
                    log.GetComponent<Rigidbody>().isKinematic = true;
                }
                isControlEnable = false;
                //GetComponent<SphereCollider>().enabled = false;
                trigger.enabled = false;
                health--;
                Invoke("DeathSequence", levelLoadDelay);
               
                break;
        }
    }

    

    private void DeathSequence()
    {

        isControlEnable = true;
        // GetComponent<SphereCollider>().enabled = true;
        transform.position = checkPoint;
        deathCollider.position = transform.position + offset;
        trigger.enabled = true;

        foreach (GameObject log in logs)
        {
             log.GetComponent<Rigidbody>().isKinematic = false;
        }

    }

   
}
