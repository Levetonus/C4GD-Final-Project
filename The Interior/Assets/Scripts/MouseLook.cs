using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public static MouseLook instance;

    public float sensitivity = 1500f;
    public Transform playerBody;
    float xRotation = 0f;
    public Texture2D cursorTexture;

    public bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Cursor.lockState = CursorLockMode.Locked;
        if (cursorTexture != null)
        {
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            HandleMouseInput();
        }
    }

    void FixedUpdate()
    {
        if (active)
        {
            ApplyRotation();
        }
    }

    void HandleMouseInput()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.smoothDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.smoothDeltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void ApplyRotation()
    {
        // This function can be expanded if needed for more complex rotation logic
    }
}
