using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 20;
    
    private Queue<GameObject> pool = new Queue<GameObject>();

    //getter
    public int PoolSize => poolSize;

    //setter
    public void SetPoolSize(int size)
    {
        poolSize = size;
    }

    private void Awake()
    {

        for (int i = 0; i < poolSize; i++)
        {
            //create bullet
            GameObject bullet = Instantiate(bulletPrefab, transform);
            
            //deactivate the bullet, we don't want it
            bullet.SetActive(false);
            
            //add it to the queue
            pool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        if (pool.Count > 0)
        {
            GameObject bullet = pool.Dequeue();
            bullet.SetActive(true);
            Debug.Log("Using pool!");
            return bullet;
        }
        
        Debug.LogWarning("Pool is empty, INCREASE SIZE!!!");
        
        return Instantiate(bulletPrefab, transform);
    }

    public void ReleaseBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        pool.Enqueue(bullet);
    }
}
