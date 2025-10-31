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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveInput = inputAsset.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xAxisValue = moveInput.ReadValue<Vector2>().x;

        if (xAxisValue != 0f) 
        {
            rb.AddForce(Vector2.right * xAxisValue * horizontalSpeed);
            rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX, -maxHorizontalSpeed, maxHorizontalSpeed);
        }
    }
}
