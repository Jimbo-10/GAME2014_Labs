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

    public GameObject CreateBullet(BulletTag tag)
    {
        GameObject bullet = Instantiate(bulletPrefab);

       // bullet.transform.position = transform.position;
        bullet.tag = tag.ToString();
        switch (tag)
        {
            case BulletTag.PlayerBullet:
                bullet.GetComponent<BulletBehaviour>().SetDirection(new Vector3(0, 1, 0));
                bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
                bullet.GetComponent<SpriteRenderer>().color = Color.white;
                break;

            case BulletTag.EnemyBullet:
                bullet.GetComponent<BulletBehaviour>().SetDirection(new Vector3(0, -1, 0));
                bullet.transform.rotation = Quaternion.Euler(0, 0, 180);
                bullet.GetComponent<SpriteRenderer>().color = Color.green;
                break;
        }

        return bullet;
    }
}
