using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    Boundary verticalBoundary;

    Vector3 direction;
    BulletManager bulletManager;
    
    public BulletTag bulletTag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // direction = Vector3.up;
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + direction * speed * Time.deltaTime;
        if(transform.position.y > verticalBoundary.max || transform.position.y < verticalBoundary.min)
        {
            //Destroy(gameObject);
            bulletManager.ReturnBullets(gameObject, bulletTag);
        }
    }

    public void SetDirection(Vector3 dir) 
    { 
        direction = dir;
    }
}
