using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollisions : MonoBehaviour
{
    PressButtons pb;
    public bool [] buttonObjs; 

    void Start(){
        pb = GameObject.Find("Button Manager").GetComponent<PressButtons>();
    }

    void OnTriggerEnter(Collider col){
        for(int i = 0; i < buttonObjs.Length; i++){
            if(col.gameObject.tag == "Floor Button"){
                buttonObjs[i] = true;
                break;
            }
        }
    }

    void OnTriggerExit(Collider col){
        for(int i = 0; i < buttonObjs.Length; i++){
            if(col.gameObject.tag == "Floor Button"){
                buttonObjs[i] = false;
                break;
            }
        }
    }
}
