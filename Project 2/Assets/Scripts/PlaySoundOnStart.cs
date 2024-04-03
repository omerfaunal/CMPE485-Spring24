using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    public AudioSource audioSource; 

    void Start()
    {
        audioSource.Play();
    }
}
