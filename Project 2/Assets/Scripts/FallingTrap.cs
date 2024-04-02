using UnityEngine;
using System.Collections;

public class FallingTrap : MonoBehaviour
{
    public float fallSpeed = 5f; // Speed at which the trap falls
    public float riseSpeed = 2f; // Speed at which the trap rises
    public float timeBetweenFalls = 2f; // Time between each fall
    public Vector3 fallPosition; // Position where the trap falls to
    private Vector3 initialPosition; // Initial position of the trap

    void Start()
    {
        // Save the initial position of the trap
        initialPosition = transform.position;

        // Start the trap coroutine
        StartCoroutine(TrapRoutine());
    }

    // Collision Detection
    void OnCollisionEnter(Collision collision)
    {
        // Check if the trap has collided with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Call the GameOver method
            Debug.Log("Game Over");
            GameManager.instance.GameOver(false, false, true);
        }
    }


    IEnumerator TrapRoutine()
    {
        while (true)
        {
            // Fall
            yield return Fall();

            // Wait for a while before rising again
            yield return new WaitForSeconds(timeBetweenFalls);

            // Rise
            yield return Rise();

            // Wait for a while before falling again
            yield return new WaitForSeconds(timeBetweenFalls);
        }
    }

    IEnumerator Fall()
    {
        while (transform.position.y > fallPosition.y)
        {
            // Move the trap downwards
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
            yield return null;
        }
    }

    IEnumerator Rise()
    {
        while (transform.position.y < initialPosition.y)
        {
            // Move the trap upwards
            transform.Translate(Vector3.up * riseSpeed * Time.deltaTime, Space.World);
            yield return null;
        }
    }


}
