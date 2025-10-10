using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    InputActionAsset inputActions;

    InputAction moveInput;

    [SerializeField]
    Boundary verticalBoundary;

    [SerializeField]
    Boundary horizontalBoundary;

    Vector2 direction;

    public Camera camera;

    public Vector2 destination;

    [SerializeField]
    bool isMobilePlatform = false;

    [SerializeField]
    float speed;

    [SerializeField]
    GameObject bulletPrefab;

    GameController gameController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveInput = inputActions.FindAction("move");
        camera = Camera.main;
        gameController = FindObjectOfType<GameController>();
        StartCoroutine(ShootingRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        MobileInput();
       // Move();
        CheckBoundaries();  

       
    }

    IEnumerator ShootingRoutine()
    {
        yield return new WaitForSeconds(1);
        Instantiate(bulletPrefab).transform.position = transform.position;
        StartCoroutine(ShootingRoutine());
    }

    void MobileInput()
    {
        /*foreach (Touch touch in Input.touches)
        {
            destination = camera.ScreenToWorldPoint(touch.position);
        }*/

        destination = camera.ScreenToWorldPoint(moveInput.ReadValue<Vector2>());
        destination = Vector2.Lerp(transform.position, destination, speed * Time.deltaTime);
        transform.position = destination;
    }
    void Move()
    {
        direction = moveInput.ReadValue<Vector2>();
        Vector2 movementAmount = direction * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + movementAmount.x,
                                            transform.position.y + movementAmount.y, transform.position.z);
    }

    void CheckBoundaries()
    {
        float positionX = Mathf.Clamp(transform.position.x, horizontalBoundary.min, horizontalBoundary.max);
        float positionY = Mathf.Clamp(transform.position.y, verticalBoundary.min, verticalBoundary.max);

        transform.position = new Vector3(positionX, positionY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("I got hit");
            gameController.ChangeScore(-5);

            collision.GetComponent<EnemyBehaviour>().DestroyingSequence();

        }
    }
}
