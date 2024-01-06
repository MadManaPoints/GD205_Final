using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavFollow : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    PlayerMovement player;
    bool move; 
    //place for target to go
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        player = GameObject.Find("Player").GetComponent<PlayerMovement>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(player.summon){
            move = true;
            Debug.Log("YERRR");
        } else {
            move = false;
        }

        if(move){
            if(Vector3.Distance(transform.position, player.transform.position) >= 4.0f){
                agent.isStopped = false;
                agent.SetDestination(player.transform.position);
            } else {
                agent.isStopped = true;
            }

            if(agent.velocity == Vector3.zero){
                animator.SetBool("Walking", false);
            } else {
                animator.SetBool("Walking", true);
            }
        }
    }
}
