using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField]
    int bulletTotal = 50;

    //GameObject bulletPrefab;
    Queue<GameObject> playerBulletPool = new Queue<GameObject>();
    Queue<GameObject> enemyBulletPool = new Queue<GameObject>();
    List<Queue<GameObject>> pools = new List<Queue<GameObject>>();

    BulletFactory bulletFactory;
    void Start()
    {
        bulletFactory = FindObjectOfType<BulletFactory>();
        pools.Add(playerBulletPool);
        pools.Add(enemyBulletPool);

        for (int i = 0; i < bulletTotal; i++)
        {
            CreateBullet(BulletTag.PlayerBullet);
            CreateBullet(BulletTag.EnemyBullet);
        }
    }

    void CreateBullet(BulletTag tag)
    {
        GameObject bullet = bulletFactory.CreateBullet(tag);
        bullet.SetActive(false);
        bullet.transform.parent = transform;
        pools[(int)tag].Enqueue(bullet);
    }
    public GameObject GetBullets(BulletTag tag)
    {
        if (pools[(int)tag].Count == 0)
        {
            Debug.LogError("No Bullet left in the queue");
            CreateBullet(tag);
        }
        GameObject bullet = pools[(int)tag].Dequeue();
        bullet.SetActive(true);
        return bullet;
    }

    public void ReturnBullets(GameObject bullet, BulletTag tag)
    {
        bullet.SetActive(false);
        pools[(int)tag].Enqueue(bullet);
    }
}
