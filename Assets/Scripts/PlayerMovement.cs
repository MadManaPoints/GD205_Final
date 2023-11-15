using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float sprintSpeed;
    private float startSpeed;

    public float groundDrag;
    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public float gravityMultiplier = 1.5f; 
    bool readyToJump = true;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode runKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public float playerHeight; 
    public LayerMask whatIsGround;
    bool grounded;
    bool hasKey;
    public Transform orientation;
    float hInput;
    float vInput;
    Vector3 moveDirection;
    Rigidbody playerRb;
    public Material green;
    bool buttonDown;
    public bool buttonPressed; 
    Vector3 centerScreen = new Vector3(0.5f, 0.5f, 0f);
    [Header("Reticle")]
    [SerializeField] Image ret; 
    [SerializeField] Color retColor; 

    void Start()
    {
        retColor.a = 1;
        playerRb = GetComponent<Rigidbody>();
        playerRb.freezeRotation = true;
        startSpeed = moveSpeed;
        Physics.gravity *= gravityMultiplier;
    }

    private void Update(){
        //cast to the center of the screen
        Ray laser = Camera.main.ViewportPointToRay(centerScreen);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(laser, out hit)){
            if(hit.collider.tag == "Button"){
                ret.color = retColor; 

                if(Input.GetMouseButtonDown(0) && hasKey){
                    hit.collider.gameObject.GetComponent<Renderer>().material = green;
                    buttonPressed = true;
                }

            } else {
                ret.color = Color.gray;
            }
        }

    

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        //handles drag
        if(grounded){
            playerRb.drag = groundDrag; 
        } else {
            playerRb.drag = 0;
        }
    }

    private void FixedUpdate(){
        MovePlayer();
    }

    private void MyInput(){
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        //check for jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded){
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer(){
        //so you can always walk in the direction you're looking
        moveDirection = orientation.forward * vInput + orientation.right * hInput;

        if(Input.GetKey(runKey)){
            moveSpeed = sprintSpeed;
        } else {
            moveSpeed = startSpeed;
        }

        if(grounded){
            playerRb.AddForce(moveDirection.normalized * moveSpeed * 10, ForceMode.Force);
        } else if(!grounded){
            //I think the point of using the airMult is to slow down player mid-air 
            playerRb.AddForce(moveDirection.normalized * moveSpeed * 10 * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl(){
        Vector3 flatVel = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);

        if(flatVel.magnitude > moveSpeed){
            Vector3 limitVel = flatVel.normalized * moveSpeed;
            playerRb.velocity = new Vector3(limitVel.x, playerRb.velocity.y, limitVel.z);
        }
    }

    private void Jump(){
        //you want to start y at 0 so that height is always the same
        playerRb.velocity = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);

        playerRb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump(){
        readyToJump = true;
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Key"){
            hasKey = true;
            Destroy(col.gameObject);
        }

        //if(col.gameObject.tag == "Button" && hasKey){
            
       // }
    }
}
