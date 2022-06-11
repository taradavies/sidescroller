using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PatrolAI : MonoBehaviour
{
    [SerializeField] Transform _frontPoint;
    [SerializeField] Transform _endPoint;
    [SerializeField] Transform _enemySprite;
    [SerializeField] float _moveSpeed = 2f;
    float _direction = 1;
    float _positionPercent;

    void Update() 
    {
        _positionPercent += Time.deltaTime * _direction * _moveSpeed;

        Vector3 desiredFrontPosition = new Vector3(_frontPoint.position.x, _enemySprite.position.y);
        Vector3 desiredBackPosiiton = new Vector3(_endPoint.position.x, _enemySprite.position.y);

        _enemySprite.position = Vector3.Lerp(desiredFrontPosition, desiredBackPosiiton, _positionPercent);

        if (_positionPercent >= 1 && _direction == 1) 
        {
            _direction = -1;
        }
        else if (_positionPercent <= 0 && _direction == -1)
        {
            _direction = 1;
        }

    }
}
