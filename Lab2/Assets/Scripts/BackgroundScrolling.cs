using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField]
    float upperborder, lowerborder;

    [SerializeField]
    float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.down * Time.deltaTime;
        
        if(transform.position.y < lowerborder)
        {
            transform.position = new Vector3(transform.position.x, upperborder, transform.position.z);
        }
    }
}
