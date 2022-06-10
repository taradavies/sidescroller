using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("---Movement---")]
    [SerializeField] float _moveSpeed = 20f;

    [Header("Jump")]
    [SerializeField] float _jumpVelocity;

    // private variables
    Rigidbody2D _rb;
    float _horizontalInput;
    CharacterGrounding _groundChecker;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<CharacterGrounding>();
    }

    void Update() 
    {
        _horizontalInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        // move based on user input
        MoveHorizontal();

        // jumps check
        if (ShouldStartJump())
        {
            Jump();
        }
    }

    void MoveHorizontal()
    {
        _rb.velocity = new Vector2(_horizontalInput * _moveSpeed, _rb.velocity.y);
    }
    void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, _jumpVelocity);
    }

    bool ShouldStartJump()
    {
        return Input.GetButton("Jump") && _groundChecker.IsGrounded;
    }
}
