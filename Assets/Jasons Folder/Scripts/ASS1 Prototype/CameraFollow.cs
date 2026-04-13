using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Targeting")]
    public Transform target;        // Drag your Player (Capsule) here
    public Vector3 offset = new Vector3(0, 2, -5); // Default distance behind player

    [Header("Sensitivity")]
    public float mouseSensitivity = 100f;
    public float clampAngle = 80f;  // Limits how far you can look up/down

    private float rotY = 0.0f; // Rotation around the Y axis (Left/Right)
    private float rotX = 0.0f; // Rotation around the X axis (Up/Down)

    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // 1. Get Mouse Input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y"); // Inverted for natural feel

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        // 2. Clamp the vertical rotation (prevents flipping)
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        // 3. Apply Rotation
        Quaternion rotation = Quaternion.Euler(rotX, rotY, 0);

        // 4. Update Position: Move the camera to the target + rotated offset
        transform.position = target.position + (rotation * offset);
        
        // 5. Look at the player
        transform.LookAt(target.position + Vector3.up * 1.5f); // Look at player's "head"
    }
}