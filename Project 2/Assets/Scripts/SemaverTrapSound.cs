using UnityEngine;

public class SemaverTrapSound : MonoBehaviour
{
    public AudioClip collisionSound;

    private AudioSource audioSource;
    public GameObject[] objectsToActivate;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = collisionSound;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllMusic();
            audioSource.Play();
            ActivateObjects();
        }
    }

    void StopAllMusic()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
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
