using System;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private int poolSize = 100;
    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private AudioClip explosionSound;
    private AudioSource audioSource;
    
    
    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = AudioManager.AudioInstance.SFXVolume;
    }

    void Update()
    {
        audioSource.volume = AudioManager.AudioInstance.SFXVolume;
    }

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

    public void Explode(Vector3 position)
    {
        ParticleSystem explode = Instantiate(explosionEffect, position, Quaternion.identity);
        explode.Play();
        audioSource.PlayOneShot(explosionSound);

        Destroy(explode.gameObject, explode.main.duration);
    }
}
