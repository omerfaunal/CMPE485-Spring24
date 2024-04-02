using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeylaIsClose : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public Transform objectToMonitor; // Reference to the object whose distance to the player is being monitored
    public float triggerDistance = 10f; // Distance threshold for triggering the sound
    private AudioSource audioSource; // Reference to the AudioSource component
    private bool soundPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
    }

    void Update()
    {
        // Check the distance between the player and the object to monitor
        if (!soundPlayed)
        {
            // Check the distance between the player and the object to monitor
            float distance = Vector3.Distance(player.position, objectToMonitor.position);

            // If the distance is less than the trigger distance
            if (distance < triggerDistance)
            {
                // Play the sound clip
                audioSource.Play();

                // Set the flag to indicate that the sound has been played
                soundPlayed = true;
            }
        }
    }
}
