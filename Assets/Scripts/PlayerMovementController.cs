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

    [Header("---Ground Check---")]
    [SerializeField] Transform _groundCheck;
    [SerializeField] float _distanceFromGround;
    [SerializeField] LayerMask _groundMask;

    // private variables
    bool _isGrounded;
    Rigidbody2D _rb;
    float _horizontalInput;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        _horizontalInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        // check if grounded
        UpdateIsGrounded();

        // move based on user input
        MoveHorizontal();

        // jumps check
        if (ShouldStartJump())
        {
            Jump();
        }
    }

    private void MoveHorizontal()
    {
        _rb.velocity = new Vector2(_horizontalInput * _moveSpeed, _rb.velocity.y);
    }

    private void UpdateIsGrounded()
    {
        var groundSensor = Physics2D.OverlapCircle(_groundCheck.position, _distanceFromGround, _groundMask);
        _isGrounded = groundSensor != null;
    }

    void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, _jumpVelocity);
    }

    bool ShouldStartJump()
    {
        return Input.GetButton("Jump") && _isGrounded;
    }
}
