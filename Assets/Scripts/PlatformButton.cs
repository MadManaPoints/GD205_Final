using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformButton : MonoBehaviour
{
    MovePlatform platform;  
    void Start()
    {
        platform = GameObject.Find("Moving Platform").GetComponent<MovePlatform>();
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.name == "Box 3" || col.gameObject.tag == "Vessel"){
            platform.activated = true; 
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.name == "Box 3" || col.gameObject.tag == "Vessel"){
            platform.activated = false; 
        }
    }
}
