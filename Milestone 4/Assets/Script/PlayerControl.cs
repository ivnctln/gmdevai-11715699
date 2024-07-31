using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5;
    public float mouseSensitivity = 2;
    private float rotationY = 0;

    void LateUpdate()
    {
        Transform cameraTransform = Camera.main.transform;

        // WADS movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = (cameraTransform.forward * moveVertical + cameraTransform.right * moveHorizontal).normalized;
        movement.y = 0;

        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // Mouse look
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotationY = Mathf.Clamp(rotationY, -90, 90);

        cameraTransform.localEulerAngles = new Vector3(rotationY, 0, 0);
        transform.localEulerAngles = new Vector3(0, rotationX, 0);
    }
}