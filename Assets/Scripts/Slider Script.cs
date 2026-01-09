using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SliderScript : MonoBehaviour
{

   [SerializeField] UnityEngine.UI.Slider musicslider;
   [SerializeField] UnityEngine.UI.Slider sfxslider;
   [SerializeField] TextMeshProUGUI musicslidertext;
   [SerializeField] TextMeshProUGUI sfxslidertext;
    public AudioMixer mixer;

   public const string MIXER_MUSIC = "MusicVolume";
   public const string MIXER_SFX = "SfxVolume";
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicslider.onValueChanged.AddListener(SetMusicVolume);

        sfxslider.onValueChanged.AddListener(SetSFXVolume);

        musicslider.onValueChanged.AddListener((v) => {
            musicslidertext.text = v.ToString("0%");
        });

        sfxslider.onValueChanged.AddListener((v) => {
            sfxslidertext.text = v.ToString("0%");
        });

        musicslider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, 1f);
        sfxslider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }


    public void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }

    public void SFXtest(float value)
    {
        AudioManager.instance.PlayButtonClip("Button Press");
    }

    public void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, musicslider.value);
        PlayerPrefs.SetFloat(AudioManager.SFX_KEY, sfxslider.value);
    }

    

    

    



}
