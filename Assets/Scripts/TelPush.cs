using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TelPush : MonoBehaviour
{
    TelButton tel; 
    float push = 20.0f;
    void Start()
    {
        tel = GameObject.Find("Floor Button 7").GetComponent<TelButton>();
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player" && tel.telTwoOn){
            col.attachedRigidbody.AddForce(Vector3.up * push, ForceMode.Impulse); 
        }
    }
}
