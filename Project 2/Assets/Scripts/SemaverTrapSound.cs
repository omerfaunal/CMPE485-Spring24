using UnityEngine;

public class SemaverTrapSound : MonoBehaviour
{
    public AudioClip collisionSound; // Sound to play when collision occurs

    private AudioSource audioSource;
    public GameObject[] objectsToActivate;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Assign the collision sound to the AudioSource component
        audioSource.clip = collisionSound;
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Stop all other music
            StopAllMusic();

            // Play the collision sound
            audioSource.Play();
            ActivateObjects();
        }
    }

    void StopAllMusic()
    {
        // Find all AudioSources in the scene
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();

        // Loop through each AudioSource and stop it if it's playing music
        foreach (AudioSource source in audioSources)
        {
            if (source != audioSource && source.isPlaying)
            {
                source.Stop();
            }
        }
    }

    void ActivateObjects()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
        }
    }
}
