using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xAxisRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseXAxis = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseYAxis = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xAxisRotation -= mouseYAxis;
        xAxisRotation = Mathf.Clamp(xAxisRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xAxisRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseXAxis);
    }
}
