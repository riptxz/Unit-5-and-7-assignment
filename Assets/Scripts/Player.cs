using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float xvel = 1;
    public float yvel;
    public float zvel = 1;

    public AudioSource audioSource;
    public AudioClip[] audioclips;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            rb.linearVelocity = Vector3.forward * xvel;
            GrassSFX();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.linearVelocity = Vector3.left * xvel;
            GrassSFX();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.linearVelocity = -Vector3.forward * xvel;
            GrassSFX();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.linearVelocity = Vector3.right * zvel;
            GrassSFX();
        }
    }

    public void GrassSFX()
    {
        audioSource.clip = audioclips[0];
        audioSource.Play();
        
    }
}
