using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBox : MonoBehaviour
{
    [SerializeField] Transform holdSpace;
    private Rigidbody boxRb;
    private PlayerMovement player; 
    void Start()
    {
        boxRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && player.holding){
            //transform.position = new Vector3(holdSpace.transform.position.x, holdSpace.transform.position.y, holdSpace.transform.position.z);
            boxRb.useGravity = false;
            boxRb.drag = 10; 
            boxRb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        if(Input.GetMouseButtonUp(0)){
            boxRb.useGravity = true;
            boxRb.drag = 0;
            boxRb.constraints = RigidbodyConstraints.None; 
        }


        if(player.holding){
            //FollowPlayer(); 
        }
    }

    void FollowPlayer(){
        if(Vector3.Distance(transform.position, holdSpace.transform.position) > 0.1f){
            Vector3 moveBox = (holdSpace.transform.position - transform.position);
            boxRb.AddForce(moveBox * 2500.0f); 
        }
    }
}
