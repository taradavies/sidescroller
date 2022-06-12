using System;
using UnityEngine;

public class Walker : MonoBehaviour
{
    [Header("---Raycast Info---")]
    [SerializeField] float _moveSpeed;
    [SerializeField] float _raycastDistance;
    [SerializeField] LayerMask _groundMask;

    Collider2D _collider;
    Rigidbody2D _rb;
    SpriteRenderer _spriteRenderer;
    Vector2 _direction;
    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _direction = Vector2.left;
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _direction * _moveSpeed * Time.fixedDeltaTime);
    }

    void LateUpdate() 
    {
        if (ReachedEgdeOfPlatform()) {
            SwitchDirections();
        }
    }
    
    bool ReachedEgdeOfPlatform()
    {
        float raycastOriginX = _direction.x == -1 ? 
        _collider.bounds.min.x - 0.1f : 
        _collider.bounds.max.x + 0.1f;

        float raycastOriginY = _collider.bounds.min.y;

        Vector2 raycastOrigin = new Vector2(raycastOriginX, raycastOriginY);

        var platformHitInfo = Physics2D.Raycast(raycastOrigin, Vector2.down, _raycastDistance, _groundMask);

        if (platformHitInfo.collider == null) {
            return true;
        }
        else {
            return false;
        }
    }

    void SwitchDirections()
    {
        _direction *= -1;
        FlipSprite();
    }

    void FlipSprite()
    {
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }
}
