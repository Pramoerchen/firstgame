using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform playerbody;
    private float xAxisClamp;


    // Start is called before the first frame update
    void Start()
    {
    Cursor.lockState = CursorLockMode.Locked;
        xAxisClamp = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }
    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        //Beschränkung des winkels
        xAxisClamp += mouseY;

        if(xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
         
        }
        else if(xAxisClamp < -90 )
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }
            

        transform.Rotate(Vector3.left * mouseY);
        playerbody.Rotate(Vector3.up * mouseX);
    }
    //Magische formel aus dem internet
    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
