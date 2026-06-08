using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float sprintMultiplier = 2f;

    [Header("Mouse Look")]
    public float sens = 100f;
    public Transform cameraPivot;

    [Header("Jump")]
    public float jumpForce = 5f;

    [Header("Ground Check")]
    public Transform feet;
    public float groundCheckDistance = 0.3f;
    public LayerMask groundMask;

    private Rigidbody rb;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    private float xRotation;

    private bool jumpPressed;
    public bool isGrounded;

    private float currentSpeed;
    private Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();

        currentSpeed = speed;

        Cursor.lockState = CursorLockMode.Locked;

        // Prevent physics rotation weirdness
        rb.freezeRotation = true;
    }

    void Update()
    {
        Look();
    }

    void FixedUpdate()
    {
        CheckGround();

        Move();

        if (jumpPressed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpPressed = false; // one jump per press
        }
    }

    void Move()
    {
        Vector3 moveDir =
            transform.right * moveInput.x +
            transform.forward * moveInput.y;

        Vector3 targetPos =
            rb.position + moveDir * currentSpeed * Time.fixedDeltaTime;

        rb.MovePosition(targetPos);
        animator.SetFloat("Walking", moveInput.magnitude, 0.1f, Time.deltaTime);
        
    }

    void Look()
    {
        float mouseX = mouseInput.x * sens * Time.deltaTime;
        float mouseY = mouseInput.y * sens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Only rotate on Y
        transform.Rotate(Vector3.up * mouseX);
    }

    void CheckGround()
    {
        isGrounded = Physics.Raycast(
            feet.position,
            Vector3.down,
            groundCheckDistance,
            groundMask
        );
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnMouse(InputAction.CallbackContext context)
    {
        mouseInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumpPressed = true;
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            currentSpeed = speed * sprintMultiplier;
        }

        if (context.canceled)
        {
            currentSpeed = speed;
        }
    }
}