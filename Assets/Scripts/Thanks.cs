using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thanks : MonoBehaviour
{
    bool ty;
    [SerializeField] GameObject thanks; 
    void Start()
    {
        thanks.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(ty){
            thanks.SetActive(true); 
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            ty = true; 
        }
    }
}
