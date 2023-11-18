using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class KeyTracker : MonoBehaviour
{
    
    private PlayerMovement playerScript;
    public Material yellow;
    public GameObject [] keys;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.keyNum == 3){
            keys[2].GetComponent<Renderer>().material = yellow;
            keys[3].GetComponent<Renderer>().material = yellow;
        } else if(playerScript.keyNum == 2){
            keys[4].GetComponent<Renderer>().material = yellow;
            keys[5].GetComponent<Renderer>().material = yellow;
        } else if(playerScript.keyNum == 1){
            keys[0].GetComponent<Renderer>().material = yellow;
            keys[1].GetComponent<Renderer>().material = yellow; 
         }
    }
}
