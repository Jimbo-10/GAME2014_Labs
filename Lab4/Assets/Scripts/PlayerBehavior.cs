using UnityEngine;
using UnityEngine.InputSystem;
using PinePie.SimpleJoystick;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    InputActionAsset inputAsset;

    InputAction moveInput;

    [SerializeField]
    JoystickController screenJoystick;

    Rigidbody2D rb;
    Animator animator;

    AnimationState state;

    [SerializeField]
    float horizontalSpeed;

    [SerializeField]
    float maxHorizontalSpeed;

    [SerializeField]
    float jumpPower;

    public bool isGrounded;

    [SerializeField]
    Transform groundPoint;

    [SerializeField]
    LayerMask groundLayerMask;

    [SerializeField]
    float groundCheckRadius;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveInput = inputAsset.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, groundCheckRadius, groundLayerMask);
        AnimationStateController();
    }
    void FixedUpdate()
    {
        Move();
        Jump();

    }

    void AnimationStateController()
    {
        if (isGrounded)
        {
            //run or idle
            if(rb.linearVelocityX != 0f)
            {
                state = AnimationState.RUN;
            }
            else
            {
                state = AnimationState.IDLE;
            }
        }
        else
        {
            //jump
            if(rb.linearVelocityY >= 0f)
            {
                state = AnimationState.JUMP;
            }
        }
        animator.SetInteger("State", (int)state);
    }
    void Move()
    {

        float xAxisValue = screenJoystick.InputDirection.x; //moveInput.ReadValue<Vector2>().x;

        if (xAxisValue != 0f)
        {
            rb.AddForce(Vector2.right * xAxisValue * horizontalSpeed);
            rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX, -maxHorizontalSpeed, maxHorizontalSpeed);

            CheckLookingDirection(xAxisValue);
        }
    }

    void Jump()
    {
        float yAxisValue = screenJoystick.InputDirection.y; //moveInput.ReadValue<Vector2>().y;

        if (isGrounded && yAxisValue > 0.7f)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    void CheckLookingDirection(float xValue)
    {
        if (xValue > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (xValue < 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundPoint.position, groundCheckRadius);
    }
}
