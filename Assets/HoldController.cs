using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldController : MonoBehaviour
{
    Rigidbody rb;
    //[SerializeField] GameObject center; 

    [SerializeField]
    PlayerMovement pm;

    [SerializeField]
    Transform holder;

    [Space(20), Header("SomethingCool"), SerializeField]
    private float holdDistance;
    [SerializeField]
    private float arbitraryNum;
    [SerializeField]
    private float holdForce;
    private bool isHeld;
    private bool snapPosition;
    bool onBlock;
    float maxSpeed = 5.0f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PushPlayer();
        //set the box being held to the player holding the box
        if(!pm.holding){
            isHeld = false; 
            gameObject.layer = 7; 
        }
        
        if(gameObject.layer == 3 && pm.holding){
            isHeld = true;
        }

        if (isHeld){
            rb.useGravity = false;
            rb.drag = 10; 
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        } else {
            rb.useGravity = true;
            rb.drag = 0;
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    void FixedUpdate()
    {
        if(isHeld)
        {
            //if(!snapPosition)
            //{
                //will leave this commented out for now. Snapping position occasionally clips through walls 
                //this snaps the position of the box to the position of the holder the moment that we grab it
            //    snapPosition = true;
            //    transform.position = holder.position;
            //}

            if (Vector3.Distance(transform.position, holder.position) > 0.2f)
            {
                //snapPosition = true; 
                //updates the position of the box using physics if we get too close to it
                Vector3 moveBox = holder.position - transform.position;
                rb.velocity = moveBox * arbitraryNum * moveBox.magnitude;
            }
        }
        else
        {
            //snapPosition = false;
            if(rb.velocity.magnitude > maxSpeed){
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            }
        }
    }

    void PushPlayer(){

        if(onBlock){
            Vector3 direction = (pm.transform.position - transform.position).normalized; 
            pm.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse); 
        }
        
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            onBlock = true; 
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player"){
            onBlock = false; 
        }
    }
}
