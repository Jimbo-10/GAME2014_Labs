using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    GameObject playerBulletPrefab;
    GameObject enemyBulletPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerBulletPrefab = Resources.Load<GameObject>("Prefabs/PlayerBullet");
        enemyBulletPrefab = Resources.Load<GameObject>("Prefabs/EnemyBullet");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject CreateBullet(BulletTag tag)
    {
        GameObject bullet;

        switch (tag)
        {
            case BulletTag.PlayerBullet:
                bullet = Instantiate(playerBulletPrefab);
                bullet.GetComponent<BulletBehaviour>().SetDirection(new Vector3(0, 1, 0));
                //bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
                //bullet.GetComponent<SpriteRenderer>().color = Color.white;
                bullet.tag = tag.ToString();
                return bullet;

            case BulletTag.EnemyBullet:
                bullet = Instantiate(enemyBulletPrefab);
                bullet.GetComponent<BulletBehaviour>().SetDirection(new Vector3(0, -1, 0));
                //bullet.transform.rotation = Quaternion.Euler(0, 0, 180);
                //bullet.GetComponent<SpriteRenderer>().color = Color.green;
                bullet.tag = tag.ToString();
                return bullet;
        }

        return null;
    }
}
