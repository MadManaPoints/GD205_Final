using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform camPos;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = camPos.position;
    }
}
