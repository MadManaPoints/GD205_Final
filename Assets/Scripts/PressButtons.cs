using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class PressButtons : MonoBehaviour
{
    public Vector3 [] pos;
    public Vector3 [] newPos;
    [SerializeField] Material green;
    [SerializeField] Material red;
    private PlayerMovement player;
    public GameObject [] buttons; 
    public bool [] pressButtons;
    BoxCollisions box;   
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        box = GameObject.Find("Box").GetComponent<BoxCollisions>();

        for(int i = 0; i < pos.Length; i++){
            pos[i] = new Vector3(buttons[i].transform.position.x, buttons[i].transform.position.y, buttons[i].transform.position.z);
            newPos[i] = new Vector3(pos[i].x, pos[i].y - 0.129f, pos[i].z);
        }
        
    }

    
    void Update()
    {
        for(int i = 0; i < box.buttonObjs.Length; i++){
            pressButtons[i] = box.buttonObjs[i];
        }

        for(int i = 0; i < pressButtons.Length; i++){
            if(pressButtons[i]){
                buttons[i].transform.position = newPos[i];
                buttons[i].GetComponent<Renderer>().material = green;    
            }
        
            if(!pressButtons[i]){
                buttons[i].transform.position = pos[i];
                buttons[i].GetComponent<Renderer>().material = red;
            }
        }
    }
}
