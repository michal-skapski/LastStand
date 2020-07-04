using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{   [SerializeField]
    private float _moveSpeed = 0f;
    [SerializeField]
    private float _walkSpeed = 4f;
    [SerializeField]
    private float _sprintSpeed = 8f;
    [SerializeField]
    private float _gravity = 0.3f;
    [SerializeField]
    private float _jumpSpeed = 6f;
    private float _movementMultiply = 0.025f;

    private Vector3 _moveDirection;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        Move();
    }
    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            _moveDirection = new Vector3(moveX * _moveSpeed, 0f, moveZ * _moveSpeed);
            _moveDirection = transform.TransformDirection(_moveDirection);
            if (Input.GetKey(KeyCode.LeftShift) && moveZ == 1)
            {
                _moveSpeed = _sprintSpeed;
            }
            else
            {
                _moveSpeed = _walkSpeed;
            }
            

            if (Input.GetKeyDown(KeyCode.Space))
                _moveDirection.y += _jumpSpeed;

        }
        _moveDirection.y -= _gravity;
        controller.Move(_moveDirection * _movementMultiply);        
    }
}
