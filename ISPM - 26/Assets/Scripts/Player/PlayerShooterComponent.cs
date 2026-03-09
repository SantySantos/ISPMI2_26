using System;
using UnityEngine;

public class PlayerShooterComponent : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    
    [SerializeField] private Transform  nozzle;


    private void Shoot()
    {
        GameObject bullet = bulletPool.GetBullet();
        
        bullet.transform.position = nozzle.position;
        bullet.transform.rotation = nozzle.rotation;
        
        bullet.GetComponent<BulletLifetimeComponent>().Initialize(bulletPool);
        bullet.GetComponent<BulletDamageComponent>().Initialize(bulletPool);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    
    
}
