using System;
using UnityEngine;

public class ObstacleDamageComponent : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private ObstaclePool obstaclePool;

    public void Initialize(ObstaclePool pool)
    {
        obstaclePool = pool;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable obstacle = other.GetComponent<IDamageable>();

        if (obstacle == null) return;

        obstacle.TakeDamage(damage);
        obstaclePool.ReleaseObstacle(gameObject);
    }
}