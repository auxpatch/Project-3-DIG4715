using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Camera Rotation
    public float mouseSensitivity = 2f;
    public float controllerSensitivity = 0.1f;
    private float verticalRotation = 0f;
    private Transform cameraTransform;

    // Ground Movement
    private Rigidbody rb;
    public float MoveSpeed = 5f;
    public float RunSpeed = 10f;
    private float moveHorizontal;
    private float moveForward;

    // Jumping
    public float jumpForce = 10f;
    public float fallMultiplier = 2.5f; // Multiplies gravity when falling down
    public float ascendMultiplier = 2f; // Multiplies gravity for ascending to peak of jump
    private bool isGrounded = true;
    public LayerMask groundLayer;
    private float groundCheckTimer = 0f;
    private float groundCheckDelay = 0.3f;
    private float playerHeight;
    private float raycastDistance;

    // Air Dash Trail
    private bool dashing = true;
    public float dashingPower = 150f;
    private float dashingTime = 0.3f;
    private float dashingCooldown = 10f;
    public WallTorchTrigger wallTorchTrigger;
    public AudioClip jumpSound;
    Animator anim;

    //Player Knockback
    private float knockbackForce = 500f;
    private float knockbackTime = 0.5f;
    private float knockBackCounter;
    //public int RoomsComplete = 0;
   
   //Player Air Dash
    public float dashDistance;
    float currentSpeed;



    [SerializeField] private TrailRenderer tr; 
    //soundManager audioManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        cameraTransform = Camera.main.transform;

        // Set the raycast to be slightly beneath the player's feet
        playerHeight = GetComponent<CapsuleCollider>().height * transform.localScale.y;
        raycastDistance = (playerHeight / 2) + 0.2f;

        // Hides the mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Allows the trail renderer to be enabled and disabled
        tr.emitting = false;
        //audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<soundManager>();
        anim = GetComponentInChildren<Animator>();
        
        
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveForward = Input.GetAxisRaw("Vertical");

        RotateCamera();
        //Debug.Log(moveForward.ToString());
        if (moveForward != 0 && isGrounded)
        {
            anim.SetInteger("State", 3);
        } else if (moveForward == 0 && isGrounded)
        {
            anim.SetInteger("State", 0);
        }

        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
            anim.SetInteger("State", 1);
            //Jump sound and animation
            soundManager.Instance.PlaySFX("Jump");
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            wallTorchTrigger.ActivateTorch();
            anim.SetInteger("State", 1);
            Debug.Log("State 0");
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            anim.SetInteger("State", 0);
            Debug.Log("State 0");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashing && !isGrounded && wallTorchTrigger.isFlameActive == true)
        {
            StartCoroutine(Dash());
        }

        // Checking when we're on the ground and keeping track of our ground check delay
        if (!isGrounded && groundCheckTimer <= 0f)
        {
            Vector3 rayOrigin = transform.position + Vector3.up * 0.1f;
            isGrounded = Physics.Raycast(rayOrigin, Vector3.down, raycastDistance, groundLayer);
            anim.SetInteger("State", 0);
        }
        else
        {
            groundCheckTimer -= Time.deltaTime;
        }

    }

    void FixedUpdate()
    {
        MovePlayer();
        ApplyJumpPhysics();
        RotateCamera();
    }

    void MovePlayer()
    {

        Vector3 movement = (transform.right * moveHorizontal + transform.forward * moveForward).normalized;
        // Shift key to sprint

        //float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : MoveSpeed;
        //float currentSpeed;
         if (Input.GetKey(KeyCode.LeftShift))
            {
                if (isGrounded)
                {
                    currentSpeed = RunSpeed;
                }
                if (!isGrounded)
                {
                    currentSpeed = dashDistance;
                }
                
            } else{
                currentSpeed = MoveSpeed;
            }
        Vector3 targetVelocity = movement * currentSpeed;

        // Apply movement to the Rigidbody
        Vector3 velocity = rb.linearVelocity;
        velocity.x = targetVelocity.x;
        velocity.z = targetVelocity.z;
        rb.linearVelocity = velocity;

        // If we aren't moving and are on the ground, stop velocity so we don't slide
        if (isGrounded && moveHorizontal == 0 && moveForward == 0)
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        }
    }

    void RotateCamera() //Rotates the camera based on the mouse and controller input
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        horizontalRotation += Input.GetAxis("Controller X") * controllerSensitivity;
        
        transform.Rotate(0, horizontalRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation -= Input.GetAxis("Controller Y") * controllerSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    void Jump() //Player's normal jump
    {
        isGrounded = false;
        groundCheckTimer = groundCheckDelay;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z); 
    }

    void ApplyJumpPhysics() //Helps the player's jump feel more natural
    {
        if (rb.linearVelocity.y < 0)
        {
            
            rb.linearVelocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.fixedDeltaTime;
        } 
        else if (rb.linearVelocity.y > 0)
        {
            
            rb.linearVelocity += Vector3.up * Physics.gravity.y * ascendMultiplier * Time.fixedDeltaTime;
        }
    }

    private IEnumerator Dash() //The player can horrizontally dash in the air 
    {
        dashing = true;
        tr.emitting = true;

        Vector3 originalGravity = Physics.gravity;
        Physics.gravity = new Vector3(0, originalGravity.y, 0);
        soundManager.Instance.PlaySFX("AirDash"); //sound effect that plays while dashing

        rb.linearVelocity = new Vector3(transform.forward.x * dashingPower, 5f, transform.forward.z * dashingPower);
        yield return new WaitForSeconds(dashingTime);
        Physics.gravity = originalGravity;
        rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
        tr.emitting = false;
                
        if (wallTorchTrigger != null)  //Toggles the flame torch to off when the player air dashes
        {
            wallTorchTrigger.TurnOffFlameParticles();
            Debug.Log("Torch Deactivated");
        }
        Debug.Log("Dashing");
        yield return new WaitForSeconds(dashingCooldown);
        dashing = true;
        Debug.Log("Dashing 2");


    }

     private void OnTriggerEnter(Collider other) //Relighting the torch for level testing
    {
        if (other.CompareTag("Torch")) 
        {
            wallTorchTrigger.ActivateTorch();
            Debug.Log("Torch Relit");
        }

        else if (other.CompareTag("Arrow")) //Causes the player to get knocked back when hit by an arrow
        {
            Vector3 knockbackDirection = (transform.position - other.transform.position).normalized;

            KnockBack(knockbackDirection);

            Debug.Log("Knockback");
        }
    }

    public void KnockBack(Vector3 direction) //How much the flamming arrows will knockback the player
    {
        knockBackCounter = knockbackTime;

        rb.linearVelocity = Vector3.zero; 
        rb.AddForce(direction.normalized * knockbackForce, ForceMode.Impulse);
    }
}
