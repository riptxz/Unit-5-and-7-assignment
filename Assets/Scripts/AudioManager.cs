using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioMixer mixer;
    public AudioSource audioSource;
    public AudioMixerGroup mixerGroup;


    public Sound[] sounds;
    public AudioClip[] audioclips;
    public float MusicVolume, SfxVolume;

    public const string MUSIC_KEY = "MusicVolume";
    public const string SFX_KEY = "SfxVolume";


    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;


            s.source.volume = s.volume;
            float pitch = s.pitch;
            s.source.pitch = pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.mixerGroup;
        }

        // if instance is null, store a reference to this instance
        if (instance == null)
        {
            // a reference does not exist, so store it
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log(SceneManager.GetActiveScene().name);
            SceneManager.sceneLoaded += SwitchMusic;
        }
        else
        {
            // Another instance of this gameobject has been made so destroy it
            // as we already have one
            Destroy(gameObject);
        }



    }

    void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume") == true)
        {

            //retrieve it and store it in a variable
            MusicVolume = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            // the key is null 
            PlayerPrefs.SetFloat("MusicVolume", 1);
        }

        if (PlayerPrefs.HasKey("SfxVolume") == true)
        {

            //retrieve it and store it in a variable
            SfxVolume = PlayerPrefs.GetFloat("SfxVolume");
        }
        else
        {
            // the key is null 
            PlayerPrefs.SetFloat("SfxVolume", 1);
        }

        if (audioSource != null && mixerGroup != null)
        {
            audioSource.outputAudioMixerGroup = mixerGroup;
        }

        LoadVolume();

    }

    public void ReplayMixer()
    {
        if(audioSource != null)
        {
            audioSource.Stop();
            audioSource.Play();
        }
    }


    public void ChangeMusicVolume(float volume)
    {
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume");
    }

    public void ChangeSFXVolume(float volume)
    {
        SfxVolume = PlayerPrefs.GetFloat("SfxVolume");
    }

    public void LoadVolume()
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);

        mixer.SetFloat(SliderScript.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat(SliderScript.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
    }

    public void SwitchMusic(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {

            audioSource.clip = audioclips[1];
            audioSource.Play();

        }
        else if (scene.buildIndex == 0)
        {
            audioSource.clip = audioclips[0];
            audioSource.Play();
        }


    }

    public void PlayButtonClip(string name)
    {
        FindFirstObjectByType<AudioManager>().PlayButtonClip(name);
    }


}
