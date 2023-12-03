using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class PressButtons : MonoBehaviour
{
    Vector3 pos;
    Vector3 newPos;
    [SerializeField] Material green;
    [SerializeField] Material red;
    private PlayerMovement player; 
    public bool pressButton;     
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        newPos = new Vector3(pos.x, pos.y - 0.129f, pos.z);
    }

    
    void Update()
    {
        if(pressButton){
         transform.position = newPos;
         this.GetComponent<Renderer>().material = green;    
        }
        
        if(!pressButton){
          transform.position = pos;
          this.GetComponent<Renderer>().material = red;
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
