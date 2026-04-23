using UnityEngine;

public class PlaneSoundComponent : MonoBehaviour
{

    private AudioSource audioSource;

    public AudioClip planeSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = AudioManager.AudioInstance.SFXVolume;
        audioSource.clip = planeSound;
        audioSource.loop = true;
        audioSource.Play();
    }

   

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = AudioManager.AudioInstance.SFXVolume;
    }
}
