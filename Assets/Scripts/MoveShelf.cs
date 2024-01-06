using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShelf : MonoBehaviour
{
    bool pressButton;
    [SerializeField] GameObject shelf;
    Vector3 shelfPos; 
    Vector3 newShelfPos;
    [SerializeField] Material green;
    [SerializeField] Material red; 
    Vector3 pos; 
    Vector3 newPos;

    void Start()
    {
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        newPos = new Vector3(pos.x, pos.y - 0.129f, pos.z);

        shelfPos = new Vector3(shelf.transform.position.x, shelf.transform.position.y, shelf.transform.position.z);
        newShelfPos = new Vector3(shelf.transform.position.x, shelf.transform.position.y, 7.0f);
    }

    void Update()
    {
        shelf.gameObject.transform.position = shelfPos;

        if(pressButton){
            transform.position = newPos;
            GetComponent<Renderer>().material = green;

            if(shelfPos.z < newShelfPos.z){
                shelfPos.z += 2.0f * Time.deltaTime;
            } else {
                shelfPos = newShelfPos;
            }
        }
        
        //probably not necessary to move shelf back 
        //if(!pressButton){
        //    transform.position = pos;
        //    GetComponent<Renderer>().material = red;
        //}
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Box" || col.gameObject.tag == "Vessel"){
            pressButton = true;
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Box" || col.gameObject.tag == "Vessel"){
            pressButton = false; 
        }
    }
}
