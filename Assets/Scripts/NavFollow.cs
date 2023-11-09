using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavFollow : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    //place for target to go
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        Ray laser = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(laser, out hit) && Input.GetMouseButtonDown(0)){
            agent.SetDestination(hit.point);
        }

        if(agent.velocity == Vector3.zero){
            animator.SetBool("Walking", false);
        } else {
            animator.SetBool("Walking", true);
        }
    }
}
