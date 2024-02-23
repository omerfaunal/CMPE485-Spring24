using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Assign your player's transform here in the Inspector
    public Vector3 offset; // Adjustable offset from the player

    void Update()
    {
        // Update camera's position to follow the player with an offset
        transform.position = player.position + offset;
    }
}
