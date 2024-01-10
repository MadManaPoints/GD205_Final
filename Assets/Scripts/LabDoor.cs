using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LabDoor : MonoBehaviour
{
    //***In a rash decision, this actually works on the chambers and not the door 
    private float moveSpeed = 1.0f;
    private PlayerMovement playerScript;
    Vector3 pos;
    Vector3 newPos;
    [SerializeField] Material red; 
    [SerializeField] Material green;
    [SerializeField] GameObject pod;
    [SerializeField] GameObject [] chambers; 
    Vector3 podPos;
    [SerializeField] Vector3 [] chamberPos; 
    [SerializeField] bool open;
    float stop = 0.0f; 
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();

        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        newPos = new Vector3(pos.x, pos.y - .04f, pos.z);

        podPos = new Vector3(pod.transform.position.x, pod.transform.position.y, pod.transform.position.z);

        for(int i = 0; i < chambers.Length; i++){
            chamberPos[i] = chambers[i].transform.position; 
        }
    }

    
    void Update()
    {
        pod.transform.position = podPos;

        for(int i = 0; i < chambers.Length; i++){
            chambers[i].transform.position = chamberPos[i]; 
        }

        if(playerScript.redButtonPressed){
            transform.position = newPos;
            GetComponent<Renderer>().material = green;
            open = true; 
        }

        if (open){
            if (podPos.y < stop){
                podPos.y += moveSpeed * Time.deltaTime;    
            } else {
                podPos.y = stop; 
            }

            for(int i = 0; i < chambers.Length; i++){
                if(chamberPos[i].y < 2.0f){
                    chamberPos[i].y += moveSpeed * Time.deltaTime;                    
                } else {
                    chamberPos[i].y = 2.0f;
                }
            }
        }
    }
}
