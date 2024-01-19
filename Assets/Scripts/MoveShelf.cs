using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShelf : MonoBehaviour
{
    bool pressButton;
    public bool inHallway; 
    [SerializeField] GameObject shelf;
    Vector3 startPos;
    Vector3 shelfPos;
    Vector3 newShelfPos;
    [SerializeField] Material green;
    [SerializeField] Material red; 
    Vector3 pos; 
    Vector3 newPos;
    [SerializeField]
    float speed = 4.0f; 

    void Start()
    {
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        newPos = new Vector3(pos.x, pos.y - 0.129f, pos.z);

        startPos = new Vector3(shelf.transform.position.x, shelf.transform.position.y, shelf.transform.position.z);

        shelfPos = new Vector3(shelf.transform.position.x, shelf.transform.position.y, shelf.transform.position.z);
        newShelfPos = new Vector3(shelf.transform.position.x, shelf.transform.position.y, 7.0f);
    }

    void Update()
    {
        shelf.gameObject.transform.position = shelfPos;

        if(pressButton && !inHallway){
            transform.position = newPos;
            GetComponent<Renderer>().material = green;

            if(shelfPos.z < newShelfPos.z){
                shelfPos.z += speed * Time.deltaTime;
            } else {
                shelfPos = newShelfPos;
            }
        }
        
        if(!pressButton || inHallway){
            transform.position = pos;

            if(shelfPos.z > startPos.z){
                shelfPos.z -= speed * Time.deltaTime; 
            } else {
                shelfPos = startPos; 
            }
        }

        if(!pressButton && !inHallway){
            GetComponent<Renderer>().material = red;
        }
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
