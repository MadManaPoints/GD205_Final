using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorOn : MonoBehaviour
{
    private float moveSpeed = 10.0f;
    private PlayerMovement playerScript;
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.buttonPressed){
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }
}
