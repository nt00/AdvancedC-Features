using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbitWithZoom : MonoBehaviour
{
    public Transform target; // The target point to rotate around
    public float distance = 5.0f; // The distance between the camera's point and the target
    public float sensitivity = 1f; // How sensitive the input is for rotating

    public float distanceMin = 0.5f; // Minimum allowed distance of camera
    public float distanceMax = 15f; // Maximum allowed distance of camera

    //Stored X and Y rotation in eulerAngles
    float x = 0.0f;
    float y = 0.0f;

    void Start()
    {
        // Get the current axis of rotation on X and Y
        Vector3 angles = transform.eulerAngles;
        // Swap over X and Y because of axis
        x = angles.y;
        y = angles.x;
    }

    void HideCursor(bool isHiding)
    {
        // Is the cursor supposed to be hiding?
        if(isHiding)
        {
            // Hide the cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            //Unhide the cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void GetInput()
    {
        // Gather X and Y mouse offset input to rotate camera (by sensitivity)
        x += Input.GetAxis("Mouse X") * sensitivity;
        // Opposite direction for Y because it is inverted
        y -= Input.GetAxis("Mouse Y") * sensitivity;

        // Get Mouse ScrollWheel input offset for changing distance
        float inputScroll = Input.GetAxis("Mouse ScrollWheel");
        distance = Mathf.Clamp(distance - inputScroll, distanceMin, distanceMax);
    }

    void Movement()
    {
        // Check if a target has been st
        if(target)
        {
            // Convert x and y rotations to Quaternion using Euler
            Quaternion rotation = Quaternion.Euler(y, x, 0);

            // Calculate new position offset using rotation
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            // Apply rotation and position to transform
            transform.rotation = rotation;
            transform.position = position;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetMouseButton(1))
        {
            HideCursor(true);
            // Get Input
            GetInput();
        }
        else
        {
            // Unhide the cursor
            HideCursor(false);
        }
        // Movement
        Movement();
    }
}
