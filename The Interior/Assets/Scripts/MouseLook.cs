using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    float yRotation = 0f;
    //public Texture2D texture;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.Current = Cursors.NoMove2D;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate the camera (attached to the player's head) vertically
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        playerBody.rotation = Quaternion.Euler(0f, yRotation, 0f);

        // Rotate the player's body horizontally
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
