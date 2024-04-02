using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public float moveSpeed = 2f; // Speed at which the object moves
    public float stoppingDistance = 1.5f;
    public float followDistance = 2f; // Distance threshold for activation
    private float followTextDistance = 3f; // Distance threshold for displaying follow text
    public KeyCode activationKey = KeyCode.K; // Key to activate following
    private Animator animator; // Reference to the Animator component
    private bool isFollowing = false; // Flag to indicate if the object is following the player
    private bool showingFollowText = false; // Flag to indicate if the follow text is being displayed

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if(!isFollowing && !showingFollowText && distance <= followDistance)
        {
            GameManager.instance.DisplayGameMessage("Press K to make Leyla follow you!");
            showingFollowText = true;
        }
        // Check if the activation key is pressed
        if (Input.GetKeyDown(activationKey))
        {
            Debug.Log("K PRESSED");
            // Activate following only if the objects are close enough
            if (distance <= followDistance)
            {
                isFollowing = !isFollowing;
            }
        }

        if (isFollowing)
        {
            // If following, handle movement and animation
            FollowPlayer();
        }
        else
        {
            // If not following, stop the animation
            animator.SetFloat("Speed", 0f);
        }
    }

    void FixedUpdate()
    {
        if (isFollowing)
        {
            // If following, handle movement using physics in FixedUpdate
            MoveTowardsPlayer();
        }
    }

    void FollowPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < stoppingDistance)
        {
            // If close, stop the animation
            animator.SetFloat("Speed", 0f);
        }
        else
        {
            // Move towards the player
            MoveTowardsPlayer();

            // Set animation speed
            float speed = moveSpeed;
            animator.SetFloat("Speed", speed);
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        Vector3 targetPosition = player.position - directionToPlayer * followDistance;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        transform.LookAt(player);
    }
}
