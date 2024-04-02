using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Play the audio clip when the game starts
        audioSource.Play();
    }
}
