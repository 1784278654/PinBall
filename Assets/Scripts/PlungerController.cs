using UnityEngine;

public class PlungerController : MonoBehaviour
{
    [SerializeField] private float plungerForce = 18f;
    [SerializeField] private float maxPullDistance = 0.5f;
    [SerializeField] private Transform plungerTop;

    private Rigidbody ballRb;
    private bool ballReady = false;
    private Vector3 initialPosition;
    private float currentPullDistance = 0f;

    private void Start()
    {
        initialPosition = plungerTop.position;
    }

    private void Update()
    {
        if (ballReady)
        {
            //charging
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                currentPullDistance = Mathf.Clamp(currentPullDistance + Time.deltaTime, 0f, maxPullDistance);
                //moving plungerTop for visual indication
                plungerTop.position = initialPosition + transform.forward * currentPullDistance * 0.5f;
            }


            //releasing the charge
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
            {
                if (ballRb != null)
                {
                    float force = plungerForce * currentPullDistance;
                    ballRb.AddForce(-transform.forward * force, ForceMode.Impulse);
                }
                currentPullDistance = 0f;
                plungerTop.position = initialPosition;

                ballReady = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if collision is the ball, enable charging(ballReady)
        if (other.CompareTag("Ball"))
        {
            ballReady = true;
            ballRb = other.GetComponent<Rigidbody>();
        }
    }
}