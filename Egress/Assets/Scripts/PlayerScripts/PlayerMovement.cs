using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    // Camera Rotation
    public float mouseSensitivity = 2f;
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

    // Air Dash 
    private bool dashing = true;
    private float dashingPower = 150f;
    private float dashingTime = 0.3f;
    private float dashingCooldown = 10f;
    public WallTorchTrigger wallTorchTrigger;


    [SerializeField] private TrailRenderer tr; 

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
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveForward = Input.GetAxisRaw("Vertical");

        RotateCamera();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashing && !isGrounded)
        {
            StartCoroutine(Dash());
        }

        // Checking when we're on the ground and keeping track of our ground check delay
        if (!isGrounded && groundCheckTimer <= 0f)
        {
            Vector3 rayOrigin = transform.position + Vector3.up * 0.1f;
            isGrounded = Physics.Raycast(rayOrigin, Vector3.down, raycastDistance, groundLayer);
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

        // Check if the Shift key is held down
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : MoveSpeed;
        Vector3 targetVelocity = movement * currentSpeed;

        // Apply movement to the Rigidbody
        Vector3 velocity = rb.velocity;
        velocity.x = targetVelocity.x;
        velocity.z = targetVelocity.z;
        rb.velocity = velocity;

        // If we aren't moving and are on the ground, stop velocity so we don't slide
        if (isGrounded && moveHorizontal == 0 && moveForward == 0)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }

    void RotateCamera()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, horizontalRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    void Jump()
    {
        isGrounded = false;
        groundCheckTimer = groundCheckDelay;
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z); 
    }

    void ApplyJumpPhysics()
    {
        if (rb.velocity.y < 0)
        {
            
            rb.velocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.fixedDeltaTime;
        } 
        else if (rb.velocity.y > 0)
        {
            
            rb.velocity += Vector3.up * Physics.gravity.y * ascendMultiplier * Time.fixedDeltaTime;
        }
    }

    private IEnumerator Dash()
    {
        dashing = true;
        tr.emitting = true;

        Vector3 originalGravity = Physics.gravity;
        Physics.gravity = new Vector3(0, originalGravity.y, 0);

        rb.velocity = new Vector3(transform.forward.x * dashingPower, 5f, transform.forward.z * dashingPower);
        yield return new WaitForSeconds(dashingTime);
        Physics.gravity = originalGravity;
        rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        tr.emitting = false;
        yield return new WaitForSeconds(dashingCooldown);
        dashing = true;

        //Flame particles toggle
        if (wallTorchTrigger != null)
        {
            wallTorchTrigger.TurnOffFlameParticles();
        }
    }
}