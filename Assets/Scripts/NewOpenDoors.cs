using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOpenDoors : MonoBehaviour
{
    [SerializeField] GameObject left;
    [SerializeField] GameObject right; 
    Vector3 startLeft;
    Vector3 startRight;
    Vector3 leftPos;
    Vector3 rightPos; 
    float newLeft; 
    float newRight;
    bool fake;
    void Start()
    {
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
        left.transform.position = leftPos;
        right.transform.position = rightPos;

        if(fake){
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
        if(fake){
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
}
