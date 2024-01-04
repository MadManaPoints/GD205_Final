using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] GameObject [] left;
    [SerializeField] GameObject [] right; 
    Vector3 startLeft;
    Vector3 startRight;
    Vector3 leftPos;
    Vector3 rightPos; 
    float newLeft; 
    float newRight;
    BoxCollisions box;
    void Start()
    {
        box = GameObject.Find("Box").GetComponent<BoxCollisions>();

        for(int i = 0; i < left.Length; i++){
            //hold start position to return when closed
            startLeft = left[i].transform.position;
            //position of doors
            leftPos = left[i].transform.position;
            //where doors stop when opened
            newLeft = left[i].transform.position.z + 4.0f; 

            startRight = right[i].transform.position;
            rightPos = right[i].transform.position;
            newRight = right[i].transform.position.z - 4.0f;
        }
    }

    
    void Update()
    {
        for(int i = 0; i < left.Length; i++){
            left[i].transform.position = leftPos;
            right[i].transform.position = rightPos;

            if(box.buttonObjs[i]){
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
            if(!box.buttonObjs[i]){
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
}
