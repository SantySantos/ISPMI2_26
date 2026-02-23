using UnityEngine;

public class Game_Music : MonoBehaviour
{
    public AudioClip ButtonSound;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.loop = true;
        audioSource.Play();
    }
    void Update()
    {
        audioSource.volume = AudioManager.AudioInstance.AudioVolume;
    }
}
