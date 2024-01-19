using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ThreeDoorButton : MonoBehaviour
{
    PlayerMovement player; 
    [SerializeField] Material red;
    [SerializeField] Material green; 
    [SerializeField] GameObject [] outerDoors; 
    [SerializeField] GameObject innerDoor;
    float newPos = 29.25f;
    float moveSpeed = 5.0f; 
    bool openInner = true; 
    bool openOuter;
    bool canPress = true;
    //this is a temporary fix so that this button isn't pressed earlier in the level
    public bool inRoom; 

    //id for inner door and od for outer
    Vector3 idPos; 
    Vector3 idStartPos;
    Vector3 idStopPos;
    [SerializeField] Vector3 [] odPos; 
    [SerializeField] Vector3 [] odStartPos; 
    [SerializeField] Vector3 [] odStopPos;

    //button position
    Vector3 pos; 
    Vector3 unpressedPos;
    Vector3 pressedPos;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();

        idStartPos = new Vector3(innerDoor.transform.position.x, innerDoor.transform.position.y, innerDoor.transform.position.z);
        idStopPos = new Vector3(idStartPos.x, idStartPos.y, newPos);
        idPos = innerDoor.transform.position; 

        for(int i = 0; i < outerDoors.Length; i++){
            odStartPos[i] = new Vector3(outerDoors[i].transform.position.x, outerDoors[i].transform.position.y, outerDoors[i].transform.position.z);
            odStopPos[i] = new Vector3(odStartPos[i].x, odStartPos[i].y, newPos);
            odPos[i] = outerDoors[i].transform.position; 
        }

        unpressedPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        pressedPos = new Vector3(unpressedPos.x, unpressedPos.y - .04f, unpressedPos.z);
        pos = unpressedPos;  
    }

    
    void Update()
    {
        innerDoor.transform.position = idPos;
        transform.position = pos; 
        

        for(int i = 0; i < outerDoors.Length; i++){
            outerDoors[i].transform.position = odPos[i]; 
        } 
        
        //if(player.redButtonPressed && inRoom){
        if(inRoom){
            DoorTracker();

            if(player.redButtonPressed){
                GetComponent<Renderer>().material = green;
                pos = pressedPos; 
            } else if(!player.redButtonPressed){
                GetComponent<Renderer>().material = red;
                pos = unpressedPos;  
            }
        }

        if(openInner){

            if(idPos.z > idStopPos.z){
                idPos.z -= moveSpeed * Time.deltaTime; 
            } else {
                idPos.z = idStopPos.z; 
            }
        }

        if(!openInner){

            if(idPos.z < idStartPos.z){
                idPos.z += moveSpeed * Time.deltaTime; 
            } else {
                idPos.z = idStartPos.z;
            }
        }

        if(openOuter){

            for(int i = 0; i < outerDoors.Length; i++){
                if(odPos[i].z > odStopPos[i].z){
                    odPos[i].z -= moveSpeed * Time.deltaTime;
                } else {
                    odPos[i].z = odStopPos[i].z;
                }
            }
        }

        if (!openOuter){
                    
            for(int i = 0; i < outerDoors.Length; i++){
                if(odPos[i].z < odStartPos[i].z){
                    odPos[i].z += moveSpeed * Time.deltaTime; 
                } else {
                    odPos[i].z = odStartPos[i].z; 
                }
            }
        }
    }

    void DoorTracker(){
        if(player.redButtonPressed && canPress){
            if(openInner){
                openOuter = true;
                openInner = false;
                canPress = false; 
            } else if(openOuter){
                openInner = true;
                openOuter = false;
                canPress = false; 
            }
        }

        if(Input.GetMouseButtonUp(0) && inRoom){
            canPress = true;
        }
    }
}
