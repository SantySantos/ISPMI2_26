using UnityEngine;

public class SFX_Sound : MonoBehaviour
{
    public AudioClip ButtonSound;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
}
