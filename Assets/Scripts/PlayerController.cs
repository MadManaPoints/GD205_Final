using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xRotation;
    private float yRotation;
    public float sensX;
    public float sensY;
    public Transform orientation; 

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        //I wonder why it has to be set up this way. Hurts me brain. 
        yRotation += mouseX;
        xRotation -= mouseY;

        //Ensures the player can't look 360 degrees up and down
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        //rotate cam and player
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0); 
    }
}
