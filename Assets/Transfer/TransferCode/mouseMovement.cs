using UnityEngine;

public class mouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    float xRotation = 0f;
    float yRotation = 0f;

    public float topClamp = 90f;
    public float bottomClamp = 90f;
    void Start()
    {
        //Locks cursor to middle of the screen
        Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        //Getting the mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * (mouseSensitivity * Time.deltaTime);

        // Rotation around x axis (Up and down)
        xRotation -= mouseY;
        // Clamp rotation
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        //Rotation around y-axis (Left and right)

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        
    }
}
