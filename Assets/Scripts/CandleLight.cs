using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLight : MonoBehaviour
{
    SpriteRenderer flame;
    PlayerMovement player;
    [SerializeField] GameObject key; 
    bool nearPew;
    bool hideKey = true; 
    void Start()
    {
        flame = GetComponent<SpriteRenderer>(); 
        flame.enabled = false;

        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        key.SetActive(false); 
    }

    
    void Update()
    {
        if(nearPew && player.crouching && hideKey){
            flame.enabled = true;
            key.SetActive(true); 
            hideKey = false; 
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            nearPew = true; 
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player"){
            nearPew = false; 
        }
    }
}
