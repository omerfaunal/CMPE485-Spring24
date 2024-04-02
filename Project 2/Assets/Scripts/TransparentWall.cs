using UnityEngine;
using System.Collections;

public class TransparentWall : MonoBehaviour
{
    public Transform object1; // Reference to the first object
    public Transform object2; // Reference to the second object
    public float maxDistance = 5f; // Maximum allowed distance between the two objects

    private Collider wallCollider; // Reference to the Collider component of the wall

    void Start()
    {
        // Get the Collider component attached to the wall
        wallCollider = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves either object1 or object2
        if (collision.transform == object1 || collision.transform == object2)
        {
            // Check the distance between the two objects
            float distance = Vector3.Distance(object1.position, object2.position);

            // If the distance exceeds the maximum allowed distance, disable the wall Collider
            // Otherwise, enable the wall Collider
            if (distance > maxDistance)
            {
                wallCollider.enabled = true; 
                GameManager.instance.DisplayGameMessage("I can't leave Leyla behind! I need to find a way to get to her.");
            }
            else
            {
                wallCollider.enabled = false;
                StartCoroutine(DelayGameOver());
            }
        }
    }

    IEnumerator DelayGameOver()
    {
        // Wait for two seconds
        yield return new WaitForSeconds(2f);

        // Call the game over method
        GameManager.instance.GameOver(true, false, false);
    }
}
