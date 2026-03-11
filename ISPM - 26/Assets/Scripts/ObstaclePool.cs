using System;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private int poolSize = 100;
    
    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obstacle = Instantiate(obstaclePrefab);
            obstacle.SetActive(false);
            pool.Enqueue(obstacle);
        }
    }

    public GameObject GetObstacle()
    {
        if (pool.Count > 0)
        {
            GameObject obstacle = pool.Dequeue();
            obstacle.SetActive(true);
            return obstacle;
        }
        
        Debug.LogWarning("Pool is empty, INCREASE SIZE!!!");
        
        return Instantiate(obstaclePrefab, transform);
    }

    public void ReleaseObstacle(GameObject obstacle)
    {
        obstacle.SetActive(false);
        pool.Enqueue(obstacle);
    }
}
