using UnityEngine;

public class FlipperController : MonoBehaviour
{
    [SerializeField] public float restPosition = 0f;
    [SerializeField] public float pressedPosition = 45f;
    [SerializeField] public float hitStrength = 10000f;
    [SerializeField] public float flipperDamper = 150f;
    [SerializeField] public KeyCode inputKey;

    private HingeJoint hingeJoint;
    private JointSpring jointSpring;

    private void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        hingeJoint.useSpring = true;

        jointSpring = new JointSpring
        {
            spring = hitStrength,
            damper = flipperDamper
        };
    }

    private void Update()
    {
        jointSpring.targetPosition = Input.GetKey(inputKey) ? pressedPosition : restPosition;
        hingeJoint.spring = jointSpring;
    }
}