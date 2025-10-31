using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    InputActionAsset inputAsset;

    InputAction moveInput;

    Rigidbody2D rb;

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
    }

    // Update is called once per frame

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, groundCheckRadius, groundLayerMask);
    }
    void FixedUpdate()
    {
        Move();
        Jump();

    }

    void Move()
    {
        float xAxisValue = moveInput.ReadValue<Vector2>().x;

        if (xAxisValue != 0f)
        {
            rb.AddForce(Vector2.right * xAxisValue * horizontalSpeed);
            rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX, -maxHorizontalSpeed, maxHorizontalSpeed);

            CheckLookingDirection(xAxisValue);
        }
    }

    void Jump()
    {
        float yAxisValue = moveInput.ReadValue<Vector2>().y;

        if (isGrounded && yAxisValue > 0)
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
