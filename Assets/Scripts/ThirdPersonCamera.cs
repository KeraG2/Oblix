using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;        // The player
    public float sensitivity = 200f;
    public float distance = 6f;
    public float minPitch = -35f;
    public float maxPitch = 60f;
    public float smoothSpeed = 10f;
    public Vector3 offset = new Vector3(0f, 1.5f, 0f);

    float yaw;
    float pitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (!target) return;

        // Mouse input
        yaw += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // Rotation
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        // Position
        Vector3 desiredPosition = target.position + offset + rotation * new Vector3(0, 0, -distance);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Look at player
        transform.LookAt(target.position + offset);
    }
}