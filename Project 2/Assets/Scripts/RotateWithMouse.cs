using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    public float rotateSpeed = 1500f; // Speed of rotation

    void Update()
    {
        // Get mouse input for horizontal and vertical rotation
        float mouseX = Input.GetAxis("Mouse X");

        // Rotate the follow target around the Y axis based on horizontal mouse input
        transform.Rotate(Vector3.up, mouseX * rotateSpeed * Time.deltaTime);

    }
}
