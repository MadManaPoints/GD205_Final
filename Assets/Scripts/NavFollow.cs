using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;

public class NavFollow : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim; 
    PlayerMovement player;
    Rigidbody rbVessel; 
    public bool move;
    bool hit; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        rbVessel = GetComponent<Rigidbody>(); 
        anim.SetBool("Active", false); 
    }

    void Update()
    {
        if(move){
            anim.SetBool("Active", true);
            //Debug.Log("YERRR");

            if(Vector3.Distance(transform.position, player.transform.position) >= 4.0f){
                agent.isStopped = false;
                agent.SetDestination(player.transform.position);
            } else {
                agent.isStopped = true;
            }

            if(agent.velocity == Vector3.zero){
                anim.SetBool("Walking", false);
            } else {
                anim.SetBool("Walking", true);
            }

        } else {
            anim.SetBool("Active", false);
            anim.SetBool("Walking", false); 
            agent.velocity = Vector3.zero; 

        }

        if(agent.velocity != Vector3.zero && !move){
            agent.velocity = Vector3.zero; 
            rbVessel.isKinematic = true; 
        }
        if(hit){
            Debug.Log("Hit");
            rbVessel.isKinematic = true;
            move = false;
            hit = false; 
        } else {
            rbVessel.isKinematic = true;
            rbVessel.isKinematic = false; 
        }
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "Wall" || col.gameObject.tag == "Player"){
            hit = true;  
        }
    }
}
