using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] GameObject button; 
    [SerializeField] Material red;
    [SerializeField] Material green;
    Rigidbody rb;
    Vector3 startPos;
    Vector3 stopPos;
    Vector3 startButtonPos;
    Vector3 newButtonPos; 
    float moveSpeed = 5.0f; 
    float stop = -8.865203f;
    float targetTime = 3.0f;
    public bool activated; 
    bool moving;
    bool atPosOne = true;
    bool atPosTwo;
    bool onBoard;
    bool startTimer = true;
    PlayerMovement player;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z); 
        stopPos = new Vector3(stop, transform.position.y, transform.position.z);

        startButtonPos = new Vector3(button.transform.position.x, button.transform.position.y, button.transform.position.z);
        newButtonPos = new Vector3(button.transform.position.x, button.transform.position.y - 0.129f, button.transform.position.z); 
    }

    void Update()
    {        
        if(activated){

            if(startTimer){
                targetTime -= Time.deltaTime;
            }
             

            if(targetTime <= 0.0f){
                moving = true;
                startTimer = false; 
                TimerEnd();
            }

            if(!moving){
                startTimer = true; 
            }

            button.transform.position = newButtonPos;
            button.GetComponent<Renderer>().material = green; 

        } else {

            button.transform.position = startButtonPos;
            button.GetComponent<Renderer>().material = red; 
        }

        
    }

    void FixedUpdate()
    {        
        //limit velocity
        //never mind - no longer using AddForce
        //if(rb.velocity.magnitude > maxSpeed){
        //    rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        //}
        

        if(moving && atPosOne){
            if(transform.position.x < stopPos.x){
                rb.MovePosition(transform.position + Vector3.right * moveSpeed * Time.deltaTime);

                //moves player when standing on platform
                if(onBoard){
                    player.GetComponent<Rigidbody>().MovePosition(player.transform.position + Vector3.right * moveSpeed * Time.deltaTime);
                }
                
            } else {
                //snap to position
                transform.position = stopPos;
                moving = false;
                atPosOne = false;
                atPosTwo = true; 
                TimerEnd();
            }
        } else if(moving && atPosTwo){
            if(transform.position.x > startPos.x){
                rb.MovePosition(transform.position + Vector3.left * moveSpeed * Time.deltaTime);

                if(onBoard){
                    player.GetComponent<Rigidbody>().MovePosition(player.transform.position + Vector3.left * moveSpeed * Time.deltaTime);
                }
            } else {
                transform.position = startPos; 
                moving = false;
                atPosTwo = false;
                atPosOne = true; 
                TimerEnd(); 
            }
        }
    }

    void TimerEnd(){ 
        targetTime = 3.0f; 
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            onBoard = true; 
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player"){
            onBoard = false; 
        }
    }
}
