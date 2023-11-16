using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class MoveStatue : MonoBehaviour
{
    [SerializeField] float speed; 
    Vector3 startPos;
    Vector3 offset; 
    private PlayerMovement playerScript;
    private GameManager gameManager; 
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); 
        startPos = transform.position;
        offset = new Vector3(transform.position.x + 5.0f, transform.position.y, transform.position.z); 
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.buttonPressed){
            if(transform.position.x < startPos.x + offset.x){
                transform.Translate(Vector3.right * -speed * Time.deltaTime);
            } else {
                transform.position = transform.position;
                gameManager.openSesame = true;  
            }
        }
    }
}
