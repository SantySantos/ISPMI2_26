using UnityEngine;
using UnityEngine.UI;

public enum Quality 
{
    low, med, high 
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager AudioInstance;

    public Slider sfxSlider;
    public Slider musicSlider;
    public Toggle musicToggle;
    public Toggle SFXToggle;


    [Range(0, 1)]
    public float SFXVolume = 0.3f;
    public float MusicVolume = 0.1f;
    public bool IsMuted = false;
    public Quality GameQuality = Quality.med;

    void Awake()
    {
        Debug.Log("Audio Manager is active");
        //Volume = VolueSlider.value ;
        if (AudioManager.AudioInstance == null)
        {
            AudioManager.AudioInstance = this; // put this instance inside MyStaticAttribute
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }

    }

    void Start()
    {
        sfxSlider.value = SFXVolume;
        musicSlider.value = MusicVolume;
    }
}
