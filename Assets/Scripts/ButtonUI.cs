
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip sfx;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Quit()
    {
        Application.Quit();
    }

    

    public void Mute()
    {
        AudioManager.instance.audioSource.mute = true;
    }

    public void Unmute()
    {
        AudioManager.instance.audioSource.mute = false;
    }

    public void DummyGame()
    {
        SceneManager.LoadScene("Dummy game");
    }

    public void Back()
    {
        SceneManager.LoadScene("Front End");
    }

    public void PlaySFX()
    {
        AudioManager.instance.PlayButtonClip("Sword 4");
    }

}
