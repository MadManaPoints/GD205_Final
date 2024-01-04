using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class NewButtonPress : MonoBehaviour
{
    [SerializeField] Vector3 pos;
    [SerializeField] Vector3 newPos;
    [SerializeField] Material green;
    [SerializeField] Material red;
    [SerializeField] bool pressButton;
    [SerializeField] GameObject left;
    [SerializeField] GameObject right; 
    Vector3 startLeft;
    Vector3 startRight;
    Vector3 leftPos;
    Vector3 rightPos; 
    float newLeft; 
    float newRight;
    void Start()
    {
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        newPos = new Vector3(pos.x, pos.y - 0.129f, pos.z);

        //hold start position to return when closed
        startLeft = left.transform.position;
        //position of doors
        leftPos = left.transform.position;
        //where doors stop when opened
        newLeft = left.transform.position.z + 4.0f; 

        startRight = right.transform.position;
        rightPos = right.transform.position;
        newRight = right.transform.position.z - 4.0f;
    }

    
    void Update()
    {
        if(pressButton){
            transform.position = newPos;
            GetComponent<Renderer>().material = green;    
        }
        
        if(!pressButton){
            transform.position = pos;
            GetComponent<Renderer>().material = red;
        }

        left.transform.position = leftPos;
        right.transform.position = rightPos;

        if(pressButton){
            //open the left door when red button is pressed
            if(leftPos.z < newLeft){
                leftPos.z += 10.0f * Time.deltaTime;  
            } else {
                leftPos.z = newLeft; 
            }

            //open the right door when red button is pressed
            if(rightPos.z > newRight){
                rightPos.z -= 10.0f * Time.deltaTime;
            } else {
                rightPos.z = newRight; 
            }
        }

        //close doors 
        if(!pressButton){
            if(leftPos.z > startLeft.z){
                 leftPos.z -= 10.0f * Time.deltaTime;
            } else {
                    leftPos.z = startLeft.z; 
            }

            if(rightPos.z < startRight.z){
               rightPos.z += 10.0f * Time.deltaTime;
            } else {
                rightPos.z = startRight.z; 
            }
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Box"){
            pressButton = true; 
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Box"){
            pressButton = false; 
        }
    }
}
