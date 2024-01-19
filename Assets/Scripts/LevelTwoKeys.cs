using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoKeys : MonoBehaviour
{
    KeyManagerTwo keyTracker;
    void Start()
    {
        keyTracker = GameObject.Find("Key Manager").GetComponent<KeyManagerTwo>(); 
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            keyTracker.levelTwoKeys += 1; 
            Destroy(gameObject); 
        }
    }
}
