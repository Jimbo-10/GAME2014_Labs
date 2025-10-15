using UnityEngine;
using System.Collections;

public class BulletShooter : MonoBehaviour
{
    [SerializeField]
    float shootingSpeed;

    [SerializeField]
    BulletTag tag;

    BulletManager bulletManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
        StartCoroutine(ShootingRoutine());
    }
    IEnumerator ShootingRoutine()
    {
        yield return new WaitForSeconds(shootingSpeed);
        //Instantiate(bulletPrefab).transform.position = transform.position;
        GameObject bullet = bulletManager.GetBullets();
        bullet.transform.position = transform.position;
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
        
        StartCoroutine(ShootingRoutine());
    }

    public void StopShooting()
    {
        StopAllCoroutines();
    }

    public void StartShooting()
    {
        StartCoroutine(ShootingRoutine());
    }
}
