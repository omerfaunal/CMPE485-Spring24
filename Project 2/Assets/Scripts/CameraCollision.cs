using UnityEngine;
using Cinemachine;

public class CameraCollision : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public LayerMask wallLayer; // Layer mask for walls

    private CinemachineVirtualCamera virtualCamera;
    public float maxDistance = 5f; // Maximum distance to check for wall collision
    private float offset = 0.1f; // Offset to move the camera away from the wall

    void Start()
    {
        // Get the main camera component
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void LateUpdate()
    {
        // Calculate direction from camera to player
        Vector3 direction = player.position - virtualCamera.transform.position;

        // Cast a ray from the camera towards the player
        RaycastHit hit;
        if (Physics.Raycast(virtualCamera.transform.position, direction, out hit, maxDistance, wallLayer))
        {
            // If the ray hits a wall, move the camera to just in front of the wall
            virtualCamera.transform.position = hit.point - direction.normalized * offset;
        }
    }
}
