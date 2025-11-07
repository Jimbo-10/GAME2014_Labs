using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    Vector2 spawnPoint = new Vector3(3, 3, 0);
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = spawnPoint;
        }
    }

    public void UpdateSpawnPoint(Vector3 checkpoint)
    {
        spawnPoint = checkpoint;
    }
}
