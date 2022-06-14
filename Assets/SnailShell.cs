using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailShell : MonoBehaviour
{
    [SerializeField] float shellSpeed = 10f;
    Collider2D _collider;
    Rigidbody2D _rb;
    Vector2 _direction;
    void Awake()
    {
        _collider = GetComponent<Collider2D>();   
        _rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        _rb.velocity = new Vector2(_direction.x * shellSpeed, _rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.WasHitByPlayer())
        {
            if (_direction.magnitude == 0)
            {
                _direction = new Vector2(GetLaunchDirection(collision), 0);
            }
            else
            {
                if (collision.WasHitFromTopSide())
                {
                    _direction = Vector2.zero;
                }
                else 
                {
                    GameManager.Instance.KillPlayer();
                }
            }
        }
    }

    float GetLaunchDirection(Collision2D collision)
    {
        return collision.GetContact(0).normal.x > 0 ? 1f: -1f;
    }
}
