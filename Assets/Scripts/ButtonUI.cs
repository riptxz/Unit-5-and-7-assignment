using UnityEngine;

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

    public void ButtonSound()
    {
        FindFirstObjectByType<AudioManager>().PlayButtonClip("Button Press");
    }
}
