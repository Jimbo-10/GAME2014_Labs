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
    
    void Start()
    {
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

    private void Reset()
    {
        transform.position = new Vector3(Random.Range(horizontalScreenBoundary.min, horizontalScreenBoundary.max),
                                                          verticalScreenBoundary.max, transform.position.z);

        speed = Random.Range(speedRange.min, speedRange.max);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }
}
