using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldController : MonoBehaviour
{
    Rigidbody rb;

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
    //float maxSpeed = 2500.0f; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //set the box being held to the player holding the box
        isHeld = pm.holding;

        if (isHeld)
        {
            
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isHeld)
        {
            if(!snapPosition)
            {
                //this snaps the position of the box to the position of the holder the moment that we grab it
                snapPosition = true;
                transform.position = holder.position;
            }

            //if (Vector3.Distance(transform.position, holder.position) > 0.2f)
            {
                //updates the position of the box using physics if we get too close to it
                Vector3 moveBox = holder.position - transform.position;
                //rb.velocity = Vector3.Lerp(rb.velocity, moveBox * arbitraryNum * moveBox.magnitude, 5 * Time.deltaTime);
                rb.velocity = moveBox * arbitraryNum * moveBox.magnitude;
            }
        }
        else
        {
            snapPosition = false;
        }


    }
}
