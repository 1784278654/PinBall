using UnityEngine;

public class BumperController : MonoBehaviour
{
    [SerializeField] private bool isActive;
    [SerializeField] private float bounceForce = 100f;
    [SerializeField] private int scoreValue = 100;

    private UIManager uiManager;
    private GameManager gameManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ball")) return;

        // Special bumper behavior (unchanged)
        if (this.gameObject.CompareTag("specialBump"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                // Add score
                uiManager?.AddScore(scoreValue);

                // Play sound and effect
                gameManager.BumpFX();

                ballRb.AddForce(new Vector3(150, 0, 0), ForceMode.Force);
            }
            return;
        }


        // Active bumper behavior
        if (isActive)
        {
            // Add score
            uiManager?.AddScore(scoreValue);

            // Play sound and effect
            gameManager.BumpFX();

            // Apply bounce force
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                ballRb.AddExplosionForce(bounceForce, transform.position, 0);
                Vector3 collisionNormal = collision.contacts[0].normal;
                ballRb.velocity = Vector3.Reflect(ballRb.velocity, collisionNormal);
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (!collision.CompareTag("Ball")) return;

        if (this.gameObject.CompareTag("speedBump"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                //constant speed boost
                ballRb.velocity *= 1.1f;
            }
            return;
        }

        //last one speed decrease bump
        if (!isActive) collision.GetComponent<Rigidbody>().velocity *= 0.9f;
    }
}