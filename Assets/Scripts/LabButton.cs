using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabButton : MonoBehaviour
{
    [SerializeField] GameObject door;
    Vector3 buttonUp; 
    Vector3 buttonDown; 
    Vector3 startPos;
    Vector3 doorPos;
    [SerializeField] bool pressed; 
    float speed = 6.0f;
    float doorStop = 35.0f;
    float push = 0.09f; 
    [SerializeField] Material red;
    [SerializeField] Material green; 
    void Start()
    {
        buttonUp = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        buttonDown = new Vector3(transform.position.x, transform.position.y - push, transform.position.z);

        startPos = door.transform.position;
        doorPos = startPos; 
    }

    
    void Update()
    {
        door.transform.position = doorPos; 

        if(pressed){
            transform.position = buttonDown; 
            GetComponent<Renderer>().material = green;

            if(doorPos.x < doorStop){
                doorPos.x += speed * Time.deltaTime;  
            } else {
                doorPos.x = doorStop; 
            }
            
        }

        if(!pressed){
            transform.position = buttonUp; 
            GetComponent<Renderer>().material = red;

            if(doorPos.x > startPos.x){
                doorPos.x -= speed * Time.deltaTime;
            } else {
                doorPos.x = startPos.x; 
            }
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Vessel"){
            pressed = true; 
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Vessel"){
            pressed = false; 
        }
    }
}
