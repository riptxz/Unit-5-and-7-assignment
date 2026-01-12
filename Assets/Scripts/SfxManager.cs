using UnityEditor;
using UnityEngine;


public class SfxManager : MonoBehaviour
{

    public static SfxManager instance;
    public AudioClip[] audioclips;
    public AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SFXPlay()
    {
        audioSource.clip = audioclips[0];
        audioSource.Play();
    }
}
