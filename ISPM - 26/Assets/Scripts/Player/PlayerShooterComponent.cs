using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShooterComponent : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    
    [SerializeField] private Transform  nozzle;

    [SerializeField] private Transform flashpoint;

    [SerializeField] private ParticleSystem muzzleflash;

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
            ParticleSystem flash = Instantiate(muzzleflash, flashpoint.position, Quaternion.identity);
            flash.Play();
            Destroy(flash.gameObject, 0.2f);
        }
    }
    
    
}
