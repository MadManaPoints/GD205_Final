using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoKeyTracker : MonoBehaviour
{
    KeyManagerTwo keyCounter;
    
    void Start()
    {
        keyCounter = GameObject.Find("Key Manager").GetComponent<KeyManagerTwo>();
    }

    void Update()
    {
        
    }
}
