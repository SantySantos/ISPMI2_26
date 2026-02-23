using UnityEngine;
using UnityEngine.UI;

public enum Quality 
{
    low, med, high 
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager AudioInstance;
    public Slider AudioSlider;

    [Range(0, 1)]
    public float AudioVolume = 0.3f;
    public bool IsMuted = false;
    public Quality GameQuality = Quality.med;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
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
}
