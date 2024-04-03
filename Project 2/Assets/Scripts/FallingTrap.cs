using UnityEngine;
using System.Collections;

public class FallingTrap : MonoBehaviour
{
    public float fallSpeed = 5f; 
    public float riseSpeed = 2f; 
    public float timeBetweenFalls = 2f; 
    public Vector3 fallPosition; 
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(TrapRoutine());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            GameManager.instance.GameOver(false, false, true);
        }
    }

    IEnumerator TrapRoutine()
    {
        while (true)
        {
            yield return Fall();
            yield return new WaitForSeconds(timeBetweenFalls);
            yield return Rise();
            yield return new WaitForSeconds(timeBetweenFalls);
        }
    }

    IEnumerator Fall()
    {
        while (transform.position.y > fallPosition.y)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
            yield return null;
        }
    }

    IEnumerator Rise()
    {
        while (transform.position.y < initialPosition.y)
        {
            transform.Translate(Vector3.up * riseSpeed * Time.deltaTime, Space.World);
            yield return null;
        }
    }


}
