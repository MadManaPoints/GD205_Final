using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointOne : MonoBehaviour
{
    [SerializeField] Transform respawn;
    [SerializeField] Transform respawnBox;
    [SerializeField] GameObject respawnCam;
    PlayerMovement player;

    void Start(){
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    
    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            player.transform.position = respawn.transform.position; 
        }

        if(col.gameObject.tag == "Box"){
            col.gameObject.transform.position = respawnBox.transform.position; 
        }
    }
}
