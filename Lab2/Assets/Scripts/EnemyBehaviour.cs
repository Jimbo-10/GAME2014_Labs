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
        speed = Random.Range(speedRange.min, speedRange.max);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < verticalScreenBoundary.min)
        {
            transform.position = new Vector3(Random.Range(horizontalScreenBoundary.min, horizontalScreenBoundary.max),
                                                          verticalScreenBoundary.max, transform.position.z);

            speed = Random.Range(speedRange.min, speedRange.max);
        }
    }
}
