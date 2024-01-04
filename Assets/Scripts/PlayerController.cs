using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private float xRotation;
    private float yRotation;
    public float sens = 50f;
    public Transform orientation;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(gameManager.startGame){
            Cursor.lockState = CursorLockMode.Locked; 
            CameraControls();
        }
    }

    private void CameraControls(){
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sens;

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
