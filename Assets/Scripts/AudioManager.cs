using System;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    public float MusicVolume, SfxVolume;

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
        }

        // if instance is null, store a reference to this instance
        if (instance == null)
        {
            // a reference does not exist, so store it
            instance = this;
            DontDestroyOnLoad(gameObject);
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

    }

    public void PlayButtonClip(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();

    }

    public void ChangeMusicVolume(float volume)
    {
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume");
    }

    public void ChangeSFXVolume(float volume)
    {
        SfxVolume = PlayerPrefs.GetFloat("SfxVolume");
    }




}
