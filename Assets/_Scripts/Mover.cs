using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Mover : MonoBehaviour
{
    [SerializeField] protected Transform _frontPoint;
    [SerializeField] protected Transform _endPoint;
    [SerializeField] protected float _moveSpeed = 2f;
    
    float _direction = 1;
    float _positionPercent;

    void Update()
    {
        _positionPercent += Time.deltaTime * _direction * _moveSpeed;

        MovePosition();

        if (_positionPercent >= 1 && _direction == 1)
        {
            _direction = -1;
        }
        else if (_positionPercent <= 0 && _direction == -1)
        {
            _direction = 1;
        }

    }

    void MovePosition()
    {
        Vector3 desiredFrontPosition = new Vector3(_frontPoint.position.x, transform.position.y);
        Vector3 desiredBackPosiiton = new Vector3(_endPoint.position.x, transform.position.y);

        transform.position = Vector3.Lerp(desiredFrontPosition, desiredBackPosiiton, _positionPercent);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.WasHitByPlayer())
        {
            CollidedWithPlayer(collision);
        }
    }

    protected abstract void CollidedWithPlayer(Collision2D collision);
}
