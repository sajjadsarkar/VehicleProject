using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public float minSpeed = 500.0f;
    public float maxSpeed = 3000.0f;
    public float currentSpeed = 500.0f;
    public float accelerationRate = 200.0f;
    public float brakingForce = 500.0f;
    public float turnSpeed = 45.0f;
    public TextMeshProUGUI speedText;
    public WheelCollider[] frontWheels;
    public WheelCollider[] rearWheels;
    public GameObject[] frontWheelVisuals;
    public GameObject[] rearWheelVisuals;

    private float horizontalInput;
    private float verticalInput;
    private bool isBraking;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        // Update speed display
        float displaySpeed = (currentSpeed - 500.0f) * 0.1f;
        if (speedText != null)
        {
            speedText.text = displaySpeed.ToString("F1") + " KM/H";
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleSteering();
        UpdateWheelVisuals();
    }

    private void HandleMovement()
    {
        if (isBraking)
        {
            ApplyBrakes();
            return;
        }

        // Accelerate or decelerate based on vertical input
        if (verticalInput != 0)
        {
            currentSpeed += verticalInput * accelerationRate * Time.fixedDeltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
        }
        else
        {
            // Natural deceleration when no input
            currentSpeed = Mathf.MoveTowards(currentSpeed, minSpeed, accelerationRate * 0.5f * Time.fixedDeltaTime);
        }

        // Apply torque to wheels
        float torque = verticalInput * currentSpeed;
        foreach (var wheel in rearWheels)
        {
            wheel.motorTorque = torque;
            wheel.brakeTorque = 0;
        }
    }

    private void HandleSteering()
    {
        float steeringAngle = horizontalInput * turnSpeed;
        foreach (var wheel in frontWheels)
        {
            wheel.steerAngle = steeringAngle;
        }
    }

    private void ApplyBrakes()
    {
        foreach (var wheel in rearWheels)
        {
            wheel.brakeTorque = brakingForce;
            wheel.motorTorque = 0;
        }
        foreach (var wheel in frontWheels)
        {
            wheel.brakeTorque = brakingForce;
        }

        currentSpeed = Mathf.MoveTowards(currentSpeed, minSpeed, brakingForce * Time.fixedDeltaTime);
    }

    private void UpdateWheelVisuals()
    {
        UpdateWheelVisuals(frontWheels, frontWheelVisuals);
        UpdateWheelVisuals(rearWheels, rearWheelVisuals);
    }

    private void UpdateWheelVisuals(WheelCollider[] colliders, GameObject[] visuals)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i] != null && visuals[i] != null)
            {
                colliders[i].GetWorldPose(out Vector3 pos, out Quaternion rot);
                visuals[i].transform.position = pos;
                visuals[i].transform.rotation = rot;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red Light"))
        {
            Debug.Log("Red Light");
        }
    }

    public void OnMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        horizontalInput = inputVector.x;
        verticalInput = inputVector.y;
    }

    public void OnBrake(InputValue value)
    {
        isBraking = value.isPressed;
    }
}
