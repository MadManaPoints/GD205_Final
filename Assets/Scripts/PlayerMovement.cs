using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float sprintSpeed;
    private float startSpeed;
    public float groundDrag;
    public MovementState state;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    float startYScale;
    bool crouching; 
    bool crawl; 

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode runKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    [Header("Ground Check")]
    public float playerHeight; 
    public LayerMask whatIsGround;
    bool grounded;
    //bool hasKey;
    public int keyNum = 0;
    bool hasBook;
    public bool placedBook;
    bool summon; 
    bool toJump = true; 
    public bool redButtonPressed;
    public bool holding;
    float raycastDist = 25.0f; 
    public Transform orientation;
    float hInput;
    float vInput;
    Vector3 moveDirection;
    Rigidbody playerRb;
    public Material green;
    bool buttonDown;
    public bool buttonPressed; 
    Vector3 centerScreen = new Vector3(0.5f, 0.5f, 0f);

    [Header("Slope Handling")]
    public float maxSlopeAngle; 
    RaycastHit slopeHit;
    float fakeGrav = 80.0f;
    bool exitSlope; 

    [Header("Reticle")]
    [SerializeField] Image ret; 
    [SerializeField] Color retColor;
    
    public MeshRenderer meshRender;
    private GameManager gameManager;
    private PlayerController playerController;
    PlayerControls controller;
    
    public enum MovementState{
        walking,
        sprinting,
        crouching,
        air
    }
    
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player Cam").GetComponent<PlayerController>();
        retColor.a = 1;
        playerRb = GetComponent<Rigidbody>();
        playerRb.freezeRotation = true;
        startSpeed = moveSpeed;
        startYScale = transform.localScale.y;
    }

    private void Update(){
        //rotates player
        if(gameManager.startGame){
            //transform.eulerAngles = new Vector3(0f, playerController.transform.eulerAngles.y, 0f);
        }

        //cast to the center of the screen
        Ray laser = Camera.main.ViewportPointToRay(centerScreen);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(laser, out hit, raycastDist)){
            if(hit.collider.tag == "Button" || hit.collider.tag == "Missing Book" || hit.collider.tag == "Missing Book Key" || hit.collider.tag == "Box" || hit.collider.tag == "Vessel"){
                ret.color = retColor;
            } else {
                ret.color = Color.gray;
            }

                //activates button 
            if(Input.GetMouseButtonDown(0) && hit.collider.tag == "Button"){
                if(Vector3.Distance(transform.position, hit.collider.transform.position) <= 3.0f){
                    redButtonPressed = true;
                    if(keyNum == 3){
                        hit.collider.gameObject.GetComponent<Renderer>().material = green;
                        buttonPressed = true;
                    }
                }
            } else if(Input.GetMouseButtonUp(0)){
                redButtonPressed = false;
            }

                //adds missing book in library
            if(Input.GetMouseButtonDown(0) && hasBook && hit.collider.tag == "Missing Book Key"){
                MeshRenderer m = meshRender.GetComponent<MeshRenderer>();
                m.enabled = true;
                placedBook = true;
                hasBook = false;
            }

            if(Input.GetMouseButtonDown(0) && !hasBook && hit.collider.tag == "Missing Book"){
                Destroy(hit.transform.gameObject);
                hasBook = true;
            }

            if(Input.GetMouseButtonUp(0)){
                holding = false;
            }
            
            if(Input.GetMouseButtonDown(0) && hit.rigidbody && hit.collider.tag == "Box" && grounded){
                hit.collider.gameObject.layer = 3; 
                if (Vector3.Distance(transform.position, hit.collider.transform.position) <= 5.0f){
                    holding = true;
                }
            }

            if(Input.GetMouseButtonUp(0) && hit.collider.tag == "Vessel" && !summon){
                if(Vector3.Distance(transform.position, hit.collider.transform.position) <= 10.0f){
                    summon = true;
                    hit.collider.gameObject.GetComponent<NavFollow>().move = true; 
                }
            } else if (Input.GetMouseButtonUp(0) && hit.collider.tag == "Vessel" && summon){
                if(Vector3.Distance(transform.position, hit.collider.transform.position) <= 10.0f){
                    summon = false;
                    hit.collider.gameObject.GetComponent<NavFollow>().move = false; 
                }
            }
        }

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        if(gameManager.startGame){
            MyInput();
        }
        SpeedControl();
        StateHandler();

        //handles drag
        if(grounded){
            playerRb.drag = groundDrag; 
        } else {
            playerRb.drag = 0;
        }
    }

    private void FixedUpdate(){
        if(gameManager.startGame){
            MovePlayer();
        }
    }

    private void MyInput(){
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        //check for jump
        if(toJump){
            if(Input.GetKeyDown(jumpKey) && readyToJump && grounded){
                toJump = false;
                readyToJump = false;
                Jump();
                Invoke(nameof(ResetJump), jumpCooldown);
            }
        }

        if(!toJump && Input.GetKeyUp(jumpKey)){
            toJump = true;
        }

        if(Input.GetKeyDown(crouchKey) && !crouching){
            crouching = true; 
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            playerRb.AddForce(Vector3.down * 5.0f, ForceMode.Impulse);
        } else if(Input.GetKeyDown(crouchKey) && crouching){
            if(!crawl){
                crouching = false; 
                transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
            }
        }
    }

    private void StateHandler(){
        if(crouching){
            state = MovementState.crouching; 
            moveSpeed = crouchSpeed; 
        } else if(grounded && Input.GetKey(runKey)){
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        } else if(grounded){
            state = MovementState.walking;
            moveSpeed = startSpeed;
        } else {
            state = MovementState.air; 
        }
    }

    private void MovePlayer(){
        //so you can always walk in the direction you're looking
        moveDirection = orientation.forward * vInput + orientation.right * hInput;

        if(OnSlope() && !exitSlope){
            playerRb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20.0f, ForceMode.Force);

            //add downward force to keep player on slope since grav is turned off
            if(playerRb.velocity.y > 0){
                playerRb.AddForce(Vector3.down * fakeGrav, ForceMode.Force); 
            }
        }

        if(grounded){
            playerRb.AddForce(moveDirection.normalized * moveSpeed * 10, ForceMode.Force);
        } else if(!grounded){
            //I think the point of using the airMult is to slow down player mid-air 
            playerRb.AddForce(moveDirection.normalized * moveSpeed * 10 * airMultiplier, ForceMode.Force);
        }

        //turn off gravity while on slope
        playerRb.useGravity = !OnSlope(); 
    }

    private void SpeedControl(){
        //limit speed on slope
        if(OnSlope() && !exitSlope){
            if(playerRb.velocity.magnitude > moveSpeed){
                playerRb.velocity = playerRb.velocity.normalized * moveSpeed;
            }

        } else {

            Vector3 flatVel = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);

            if(flatVel.magnitude > moveSpeed){
                Vector3 limitVel = flatVel.normalized * moveSpeed;
                playerRb.velocity = new Vector3(limitVel.x, playerRb.velocity.y, limitVel.z);
            }
        }        
    }

    private void Jump(){
        exitSlope = true; 
        //you want to start y at 0 so that height is always the same
        playerRb.velocity = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);

        playerRb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump(){
        readyToJump = true;
        exitSlope = false; 
    }

    private bool OnSlope(){
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f)){
            //calculate how steep the slope is
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0; 
        }
        //if raycast doesn't hit a slope
        return false; 
    }

    private Vector3 GetSlopeMoveDirection(){
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized; 
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Crawl Space"){
            crawl = true; 
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Crawl Space"){
            crawl = false; 
        }
    }
}
