using UnityEngine;

public class BallController : MonoBehaviour
{
    //[SerializeField] private float minVelocity = 5f;
    [SerializeField] private float outOfBoundsY = -5f;

    private Rigidbody rb;
    private GameManager gameManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        /*
        // Prevent ball from getting stuck with too low velocity
        if (rb.velocity.magnitude < minVelocity && rb.velocity.magnitude > 0)
        {
            rb.velocity = rb.velocity.normalized * minVelocity;
        }
        */

        // Check if ball fell out of bounds
        if (transform.position.y < outOfBoundsY)
        {
            gameManager?.BallLost();
            Destroy(gameObject);
        }
    }
}