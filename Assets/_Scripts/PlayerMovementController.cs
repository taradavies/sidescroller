using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterGrounding))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour, IMove
{
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _jumpVelocity;
    [SerializeField] float coyoteTime;
    float coyoteTimeCounter;

    // private variables
    Rigidbody2D _rb;
    CharacterGrounding _groundChecker;
    float _horizontalInput;

    public float Speed { get; private set; }

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<CharacterGrounding>();
    }

    void Update() 
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        Speed = _horizontalInput;

        IncrementCoyoteTimeCounter();

        // jumps check
        if (ShouldStartJump())
        {
            Jump();
        }
        if (ShouldVariableJump()) 
        {
            VariableJump();
        }
    }

    void IncrementCoyoteTimeCounter()
    {
        if (_groundChecker.IsGrounded) {
            coyoteTimeCounter = coyoteTime;
        }
        else {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        MoveHorizontal();
    }

    private void VariableJump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, _jumpVelocity * 0.5f);
        coyoteTimeCounter = 0;
    }

    private bool ShouldVariableJump()
    {
        return Input.GetButtonUp("Jump") && _rb.velocity.y > 0;
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
        return coyoteTimeCounter > 0 && Input.GetButtonDown("Jump");
    }
}
