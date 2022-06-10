using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    Animator _animator;
    IMove _mover;
    SpriteRenderer _spriteRenderer;
    float _moveSpeed;
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<IMove>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() 
    {
        _moveSpeed = _mover.Speed;
        UpdateAnimator();
        FlipSprite();
    }

    void FlipSprite()
    {
        if (_moveSpeed != 0)
            _spriteRenderer.flipX = _moveSpeed > 0;
    }

    void UpdateAnimator()
    {
        _animator.SetFloat("Speed", Mathf.Abs(_moveSpeed));
    }
}
