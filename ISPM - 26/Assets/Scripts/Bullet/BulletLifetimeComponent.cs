using System;
using UnityEngine;

public class BulletLifetimeComponent : MonoBehaviour
{
    [SerializeField] private float lifetime = 5f;

    private float timer;
    private BulletPool bulletPool;

    public void Initialize(BulletPool bulletPool)
    {
        timer = 0f;
        this.bulletPool = bulletPool;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= lifetime)
        {
            bulletPool.ReleaseBullet(gameObject);
        }
    }
}
