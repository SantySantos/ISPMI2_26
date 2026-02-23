using UnityEngine;

public class SFX_Sound : MonoBehaviour
{
    [Header("SFX")]
    public AudioClip ButtonSound;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 0f;
        audioSource.volume = AudioManager.AudioInstance.AudioVolume;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = AudioManager.AudioInstance.AudioVolume;
    }
    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(ButtonSound);
        //Debug.Log("Clicked");
    }
    public void SetSFXVolume(float value)
    {
        AudioManager.AudioInstance.AudioVolume = value;
    }
}
