using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneCollisions : MonoBehaviour
{
    private PlayerMovement player;
    private SceneOneManager sceneOneManager;
    private GameManager gameManager;
    private PlayerController playerCam;
    [SerializeField] Transform target;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        sceneOneManager = GameObject.Find("Scene One Manager").GetComponent<SceneOneManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); 
        playerCam = GameObject.Find("Player Cam").GetComponent<PlayerController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(player.placedBook){
            sceneOneManager.teleporterOn = true;
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Key"){
            player.keyNum += 1;
            Destroy(col.gameObject);
        }

        if(col.gameObject.tag == "Book Key"){
            Destroy(col.gameObject);
            sceneOneManager.letThereBeLight = true; 
        }

        if(col.gameObject.tag == "Teleporter 1" && sceneOneManager.teleporterOn){
            transform.position  = new Vector3(transform.position.x, 15.0f, transform.position.z);
        }

        if(col.gameObject.tag == "Level Two"){
            gameManager.levelTwo = true;
        }
    }
}
