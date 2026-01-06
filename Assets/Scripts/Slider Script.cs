using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{

   [SerializeField] Slider musicslider;
   [SerializeField] Slider sfxslider;
    public AudioMixer mixer;

    const string MIXER_MUSIC = "MusicVolume";
    const string MIXER_SFX = "SfxVolume";


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicslider.onValueChanged.AddListener(SetMusicVolume);

    

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, value);
    }
}
