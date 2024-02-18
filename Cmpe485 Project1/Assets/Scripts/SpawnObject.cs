using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject bouncyPrefab;
    public GameObject slipperyPrefab;
    public Transform playerTransform; // Assign the player's transform here through the Inspector
    public Vector3 spawnOffset; // An offset for where the object will be spawned relative to the player

    void Update()
    {
        // If B key is pressed spawn bouncy next to the player
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(bouncyPrefab, playerTransform.position + spawnOffset, Quaternion.identity);
        }

        // If S key is pressed spawn slippery next to the player
        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(slipperyPrefab, playerTransform.position + spawnOffset, Quaternion.identity);
        }
    }
}
