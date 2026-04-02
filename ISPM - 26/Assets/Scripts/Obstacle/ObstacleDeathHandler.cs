using System;
using UnityEngine;

public class ObstacleDeathHandler : MonoBehaviour
{
    
    [SerializeField] private GameEvent onDeath;
    private ObstaclePool pool;
    
    
    public void Initialize(ObstaclePool obstaclePool)
    {
        pool = obstaclePool;
        GetComponent<HPSystemComponent>().Initialize();
        GetComponent<HPSystemComponent>().OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        onDeath.RaiseEvent();
        GetComponent<HPSystemComponent>().OnDeath -= OnDeath;
        pool.ReleaseObstacle(gameObject);
    }
}
