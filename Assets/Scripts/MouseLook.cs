using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerTransform;

    public Vector2 xRotationClamp = new Vector2(-90f, 90f);
    public Vector2 yRotationClamp = new Vector2(-360,360);

    float xRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, xRotationClamp.x, xRotationClamp.y);

        transform.localRotation = Quaternion.Euler(xRotation, transform.localRotation.y , transform.localRotation.z);
        playerTransform.Rotate(playerTransform.up * mouseX, Space.World);
        playerTransform.eulerAngles = new Vector3(playerTransform.eulerAngles.x, Mathf.Clamp(playerTransform.eulerAngles.y, yRotationClamp.x, yRotationClamp.y), playerTransform.eulerAngles.z);
    }
}
