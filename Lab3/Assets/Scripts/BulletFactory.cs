using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    GameObject bulletPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        return bullet;
    }
}
