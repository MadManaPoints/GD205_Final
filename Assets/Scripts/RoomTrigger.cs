using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    ThreeDoorButton button;
    void Start()
    {
        button = GameObject.Find("Room Button").GetComponent<ThreeDoorButton>();
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            button.inRoom = true; 
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player"){
            button.inRoom = false; 
        }
    }
}
