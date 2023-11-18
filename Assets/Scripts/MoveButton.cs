using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
    private PlayerMovement playerScript;
    Vector3 pos;
    Vector3 newPos; 
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        newPos = new Vector3(pos.x, pos.y - .04f, pos.z);
    }

    void Update()
    {
        if(playerScript.redButtonPressed){
            transform.position = newPos;
        } else {
            transform.position = pos; 
        }
    }
}
