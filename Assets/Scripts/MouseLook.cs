using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0;
    public InGameMenus GameMenus;
    // Start is called before the first frame update
    void Start()
    {
        GameMenus = InGameMenus.instance;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameMenus.isPaused)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.unscaledDeltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.unscaledDeltaTime;



            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            // Debug.Log("MouseX: " + mouseX);
            if (Input.GetKey(KeyCode.G))
            {
                Debug.Log("xRotation: " + xRotation);
            }
            // Debug.Log("xRotation: " + xRotation);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
   

    }
}
