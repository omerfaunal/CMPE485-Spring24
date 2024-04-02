using UnityEngine;

public class GenericSoundManager : MonoBehaviour
{
    public AudioClip genericSound; // The generic sound clip to play
    private AudioSource audioSource; // Reference to the AudioSource component
    private bool isMuted = false; // Flag to indicate whether the sound is muted

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
    }

    void Update()
    {
        // Check for key press to toggle mute state
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMute();
        }

        // Check if the sound is not muted
        if (!isMuted)
        {
            // Play the generic sound clip if it's not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(genericSound);
            }
        }
    }

    void ToggleMute()
    {
        // Toggle the mute state
        isMuted = !isMuted;

        // If the sound is muted, stop the audio playback
        if (isMuted)
        {
            audioSource.Stop();
        }
    }
}
