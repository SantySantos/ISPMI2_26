using System;
using UnityEngine;

public class BulletDamageComponent : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    
    public event Action<GameObject> OnHit;
    
    private BulletPool bulletPool;

    public void Initialize(BulletPool bulletPool)
    {
        this.bulletPool = bulletPool;
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        IDamageable obstacle = collision.GetComponent<IDamageable>();
        
        if(obstacle == null)
            return;
        
        obstacle.TakeDamage(damage);
        
        OnHit?.Invoke(collision.gameObject);
        
        bulletPool.ReleaseBullet(gameObject);
        
    }
}
