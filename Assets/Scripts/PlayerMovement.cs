using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 4.0f;
    private CharacterController _controller;
    private float _gravity = 10f;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    
    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),  -_gravity,Input.GetAxis("Vertical"));
        Move(direction);

    }

    private  void Move(Vector3 direction)
    {
        direction = transform.TransformDirection(direction);
        direction *= _speed;
        _controller.Move(direction * Time.deltaTime);
    }
}

