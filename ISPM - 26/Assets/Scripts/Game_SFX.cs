using UnityEngine;

public class Game_SFX : MonoBehaviour
{
    [Header("SFX")]
    public AudioClip ButtonSound;
    private AudioSource audioSource;
    float LastVolume;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 0f;
        audioSource.volume = AudioManager.AudioInstance.SFXVolume;
        //Debug.Log(gameObject.name + "has SFX scripts");
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = AudioManager.AudioInstance.SFXVolume;
    }
    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(ButtonSound);
        //Debug.Log("Clicked");
    }
    public void SetSFXVolume(float value)
    {
        AudioManager.AudioInstance.SFXVolume = value;
        AudioManager.AudioInstance.SFXToggle.isOn = false;
    }
    public void MuteSFX(bool IsOn)
    {

        if (AudioManager.AudioInstance.SFXToggle.isOn)
        {            
            LastVolume = AudioManager.AudioInstance.SFXVolume;
            AudioManager.AudioInstance.SFXVolume = 0f;
        }
        else
        {
            AudioManager.AudioInstance.SFXVolume = LastVolume;
            PlayButtonSound();
        }
    }

}
