using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallTrigger : MonoBehaviour
{
    MoveShelf shelf; 
    void Start()
    {
        shelf = GameObject.Find("Floor Button 3").GetComponent<MoveShelf>();
    }
    
    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            shelf.inHallway = true; 
        }
    }
}
