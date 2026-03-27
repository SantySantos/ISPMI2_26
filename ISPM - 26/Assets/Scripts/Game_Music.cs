using UnityEngine;

public class Game_Music : MonoBehaviour
{
    public AudioClip GameMusic;
    private AudioSource audioSource;
    float LastVolume;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = GameMusic; 
        audioSource.loop = true;
        audioSource.Play();
        Debug.Log(gameObject.name + " Playing");
    }
    void Update()
    {
        audioSource.volume = AudioManager.AudioInstance.MusicVolume;
    }

    public void SetGameMusicVolume(float value)
    {
        AudioManager.AudioInstance.MusicVolume = value;
        AudioManager.AudioInstance.musicToggle.isOn = false;
    }
    public void MuteMusic(bool IsOn)
    {

        if (AudioManager.AudioInstance.musicToggle.isOn)
        {
            LastVolume = AudioManager.AudioInstance.MusicVolume;
            AudioManager.AudioInstance.MusicVolume = 0f;
        }
        else
        {
            AudioManager.AudioInstance.MusicVolume = LastVolume;
        }
    }
}
