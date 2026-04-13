using System;
using UnityEngine;

public class PlayerShooterComponent : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    
    [SerializeField] private Transform  nozzle;

    private AudioSource audioSource;

    public AudioClip ShotSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = AudioManager.AudioInstance.SFXVolume;
    }

    private void Shoot()
    {
        
        
        Debug.Log("SHOOOOT!");
        GameObject bullet = bulletPool.GetBullet();
        
        bullet.transform.position = nozzle.position;
        bullet.transform.rotation = nozzle.rotation;
        
        bullet.GetComponent<BulletLifetimeComponent>().Initialize(bulletPool);
        bullet.GetComponent<BulletDamageComponent>().Initialize(bulletPool);
    }
    private void Update()
    {
        audioSource.volume = AudioManager.AudioInstance.SFXVolume;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            audioSource.PlayOneShot(ShotSound);
        }
    }
    
    
}
