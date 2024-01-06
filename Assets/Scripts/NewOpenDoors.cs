using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOpenDoors : MonoBehaviour
{
    NewButtonPress buttonOne;
    bool buttonOnePress;
    //change name 
    bool c; 
    [SerializeField] Vector3 pos;
    [SerializeField] Vector3 newPos;
    [SerializeField] Material green;
    [SerializeField] Material red;
    void Start()
    {
        buttonOne = GameObject.Find("Floor Button").GetComponent<NewButtonPress>();
        //moves when pressed
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        newPos = new Vector3(pos.x, pos.y - 0.129f, pos.z);   
    }
    
    void Update()
    {
        if(buttonOnePress){
            transform.position = newPos;
            GetComponent<Renderer>().material = green;    
        }
        
        if(!buttonOnePress){
            transform.position = pos;
            GetComponent<Renderer>().material = red;
        }

        //if(buttonOnePress){
        //    buttonOne.pressButton = true;
        //} else if(!buttonOnePress){
        //    buttonOne.pressButton = false;
        //}


        //FUTURAMA! 
        if(buttonOnePress){
            buttonOne.pressButton = true;
            c = true;
        } else if(!buttonOnePress && c && !buttonOne.check){
            buttonOne.pressButton = false;
            c = false;
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Box"){
            buttonOnePress = true; 
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Box"){
            buttonOnePress = false; 
        }
    }
}
