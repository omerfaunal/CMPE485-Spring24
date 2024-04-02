using System.Collections;
using UnityEngine;

public class FlyInObject : MonoBehaviour
{
    public Vector3 targetPosition; // The position where the object should end up
    public Vector3 startPosition;
    public float flySpeed = 2f; // Speed at which the object flies in
    public AudioSource audioSource;
    public AudioClip dedeSound; // AudioClip for the dede sound
    public AudioClip mecnunSound; // AudioClip for the mecnun sound
    private bool isFlying = false; // Flag to indicate if the object is currently flying
    private bool isGoingBack = false; // Flag to indicate if the object is currently flying
    private bool isMuted = false;

    private bool mecnunPlaying = false;

    void Start()
    {
        // Start flying the object to the target position
        FlyIn();
    }

    void FlyIn()
    {
        isFlying = true;
    }

    IEnumerator StartFlyingBackAfterSound()
    {
        // Wait for the "dede" sound to finish playing
        yield return new WaitForSeconds(dedeSound.length);

        // Start flying back after the "dede" sound has finished playing
        isGoingBack = true;
    }

    void FixedUpdate()
    {
        // If the object is flying, move it towards the target position
        if (isFlying)
        {
            // Calculate the direction towards the target position
            Vector3 direction = (targetPosition - transform.position).normalized;

            // Move the object towards the target position
            transform.position += direction * flySpeed * Time.fixedDeltaTime;

            // Check if the object has reached the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                // Stop flying when the object is close to the target position
                isFlying = false;
                audioSource.PlayOneShot(dedeSound); // Play the dede sound
                StartCoroutine(StartFlyingBackAfterSound()); // Start flying back after the sound
            }
        }

        // If the object is going back
        if (isGoingBack)
        {
            if (!isMuted && !mecnunPlaying)
            {
                audioSource.PlayOneShot(mecnunSound); // Play the mecnun sound
                mecnunPlaying = true;
            }
            // Move the object towards the start position
            Vector3 backDirection = (startPosition - transform.position).normalized;
            transform.position += backDirection * flySpeed * Time.fixedDeltaTime;

            // Check if the object has reached the start position
            if (Vector3.Distance(transform.position, startPosition) < 0.1f)
            {
                // Stop going back when the object reaches the start position
                isGoingBack = false;
            }
        }
    }

     void Update()
    {
        // Toggle mecnun sound mute with 'M' key
        if (Input.GetKeyDown(KeyCode.M))
        {
            isMuted = !isMuted;
            if (isMuted)
            {
                audioSource.Stop(); // Stop the mecnun sound
                mecnunPlaying = false;
            }
            else
            {
                if (isGoingBack && !mecnunPlaying)
                {
                   audioSource.clip = mecnunSound; // Set the clip to mecnunSound
                    audioSource.loop = true; // Set the audio to loop
                    audioSource.Play(); // Play the mecnun sound continuously
                    mecnunPlaying = true;
                }
            }
        }
    }
}
