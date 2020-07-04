using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float _mouseX;
    private float _mouseY;
    private float _xRotation;
    
    [SerializeField]
    private float _mouseSensitivity; 
    //I've serialized that so i can control my mouse sensetivity from the inspector
    //We need to our mouse x and mouse y to rotate the player
    //We need a reference from our main camera to our entire first-person player
    
    [SerializeField]
    private Transform _playerBody;

    private void Start()
    {
        //I need to lock my course so when looking around our cursor won't be visible 
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void MouseLook()
    {
        _xRotation -= _mouseY;
        
        _xRotation = Mathf.Clamp(_xRotation, -45f, 45f);//we do math clampf to limit our rotation
         
        
        _mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;



        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * _mouseX);

    }
    void Update()
    {
        MouseLook();
    }
}