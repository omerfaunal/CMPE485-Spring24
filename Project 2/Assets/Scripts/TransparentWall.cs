using UnityEngine;
using System.Collections;

public class TransparentWall : MonoBehaviour
{
    public Transform object1; 
    public Transform object2;
    public float maxDistance = 5f; 

    private Collider wallCollider;

    void Start()
    {
        wallCollider = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == object1 || collision.transform == object2)
        {
            float distance = Vector3.Distance(object1.position, object2.position);

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
        yield return new WaitForSeconds(2f);

        GameManager.instance.GameOver(true, false, false);
    }
}
