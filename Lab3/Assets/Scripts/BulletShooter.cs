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
        GameObject bullet = bulletManager.GetBullets(tag);
        bullet.transform.position = transform.position;

        StartCoroutine(ShootingRoutine());
    }

   /* public void StopShooting()
    {
        StopAllCoroutines();
    }

    public void StartShooting()
    {
        StartCoroutine(ShootingRoutine());
    }*/
}
