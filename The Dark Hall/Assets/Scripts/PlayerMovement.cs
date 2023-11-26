using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed = 5.0f;
    public Camera playerCamera;
    public float lookSensitivity = 2.0f;
    private float verticalLookRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        Cursor.visible = false; // Hide the cursor
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            // Basic Movement
            float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float v = Input.GetAxis("Vertical") * speed * Time.deltaTime;

            transform.Translate(h, 0, v);

            // Player look - horizontal
            float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
            transform.Rotate(Vector3.up * mouseX);

            // Player look - vertical
            float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;
            verticalLookRotation -= mouseY;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f); // Limit vertical rotation
            playerCamera.transform.localEulerAngles = Vector3.right * verticalLookRotation;

        }
    }
}
