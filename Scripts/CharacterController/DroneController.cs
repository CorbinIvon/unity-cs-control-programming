using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DroneController : MonoBehaviour
{
    public float speed = 10.0f;
    public float strafeSpeed = 5.0f;
    public float rollSpeed = 50.0f;
    public float verticalSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;

    private Rigidbody rb;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private bool isCursorLocked = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Disable gravity for the drone
        ToggleCursorLock(true);
    }

    void Update()
    {
        // Toggle cursor lock state with Left Alt
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            isCursorLocked = !isCursorLocked;
            ToggleCursorLock(isCursorLocked);
        }

        // Only process movement and rotation if the cursor is locked
        if (isCursorLocked)
        {
            Vector3 moveDirection = Vector3.zero;

            // Forward and backward movement
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection += transform.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveDirection -= transform.forward;
            }

            // Strafing left and right
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection -= transform.right;
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveDirection += transform.right;
            }

            // Moving up and down
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection += transform.up;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection -= transform.up;
            }

            // Normalize the moveDirection vector and apply speed
            if (moveDirection != Vector3.zero)
            {
                moveDirection.Normalize();
                moveDirection *= speed;
                rb.AddForce(moveDirection * Time.deltaTime, ForceMode.VelocityChange);
            }

            // Roll rotation (rolling left and right)
            if (Input.GetKey(KeyCode.Q))
            {
                rb.AddTorque(transform.forward * rollSpeed * Time.deltaTime, ForceMode.VelocityChange);
            }
            if (Input.GetKey(KeyCode.E))
            {
                rb.AddTorque(-transform.forward * rollSpeed * Time.deltaTime, ForceMode.VelocityChange);
            }

            // Mouse input for pitch and yaw
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            rotationY = mouseX;
            rotationX = mouseY;

            // Apply torques for yaw and pitch based on mouse movement
            rb.AddTorque(transform.up * rotationY * mouseSensitivity, ForceMode.VelocityChange);
            rb.AddTorque(-transform.right * rotationX * mouseSensitivity, ForceMode.VelocityChange);
        }
    }

    private void ToggleCursorLock(bool lockCursor)
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
