using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    Boundary speedRange;

    float speed;

    [SerializeField]
    Boundary verticalScreenBoundary;

    [SerializeField]
    Boundary horizontalScreenBoundary;

    BulletManager bulletManager;
    GameController gameController;

    bool IsDying = false;

    [SerializeField]
    float shootingSpeed;
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
        gameController = FindObjectOfType<GameController>();
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.down * speed * Time.deltaTime);

        float xPos = Mathf.PingPong(Time.time * speed, horizontalScreenBoundary.max - horizontalScreenBoundary.min) + horizontalScreenBoundary.min;
        transform.position = new Vector3(xPos, transform.position.y - speed * Time.deltaTime);

        if(transform.position.y < verticalScreenBoundary.min)
        {
            Reset();
           
        }
        
    }

    private void FixedUpdate()
    {
        if (IsDying)
        {
            transform.Rotate(0, 0, 5);
            transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x - 0.05f, 0, 1), Mathf.Clamp(transform.localScale.y - 0.05f, 0, 1), 1);
        }
    }

    public void DestroyingSequence()
    {
        //GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        //GetComponent<BulletShooter>().StopShooting();
        GetComponent<SpriteRenderer>().color = Color.red;
        IsDying = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerBullet"))
        {
            DestroyingSequence();
            bulletManager.ReturnBullets(collision.gameObject, BulletTag.PlayerBullet);
            gameController.ChangeScore(5);
        }
    }
    private void Reset()
    {
        transform.position = new Vector3(Random.Range(horizontalScreenBoundary.min, horizontalScreenBoundary.max),
                                                          verticalScreenBoundary.max, transform.position.z);

        speed = Random.Range(speedRange.min, speedRange.max);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = Color.white;
        IsDying = false;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
        //GetComponent<BulletShooter>().StartShooting();
    }
}
