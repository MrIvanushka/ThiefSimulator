using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float _speed = 4.0f;
    private CharacterController _controller;
    private float gravity = 10f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    
    void FixedUpdate()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),  -gravity,Input.GetAxis("Vertical"));
        Move(direction);

    }

    public void Move(Vector3 direction)
    {
        direction = transform.TransformDirection(direction);
        direction *= _speed;
        _controller.Move(direction * Time.deltaTime);
    }
}

