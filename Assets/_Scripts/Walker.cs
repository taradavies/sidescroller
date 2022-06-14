using System;
using System.Collections;
using UnityEngine;

public class Walker : MonoBehaviour
{
    [Header("---Raycast Info---")]
    [SerializeField] float _moveSpeed;
    [SerializeField] float _raycastDistance;
    [SerializeField] LayerMask _groundMask;
    
    [Header("---Death Sprite---")]
    [SerializeField] GameObject _deathSpritePrefab;

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
        if (ReachedEgdeOfPlatform() || HitNonPlayer()) {
            SwitchDirections();
        }
    }

    bool HitNonPlayer()
    {
        float raycastOriginX = GetForwardX();
        float raycastOriginY = transform.position.y;

        Vector2 raycastOrigin = new Vector2(raycastOriginX, raycastOriginY);

        var wallHitInfo = Physics2D.Raycast(raycastOrigin, _direction, _raycastDistance);

        if (wallHitInfo.collider == null) 
        {
            return false;
        }
        else if (wallHitInfo.collider.TryGetComponent<PlayerMovementController>(out var player))
        {
            return false;
        }
        return true;
    }

    bool ReachedEgdeOfPlatform()
    {
        float raycastOriginX = GetForwardX();

        float raycastOriginY = _collider.bounds.min.y;

        Vector2 raycastOrigin = new Vector2(raycastOriginX, raycastOriginY);

        var platformHitInfo = Physics2D.Raycast(raycastOrigin, Vector2.down, _raycastDistance, _groundMask);

        if (platformHitInfo.collider == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    float GetForwardX()
    {
        return _direction.x == -1 ?
        _collider.bounds.min.x - 0.1f :
        _collider.bounds.max.x + 0.1f;
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

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.WasHitByPlayer())
        {
            if (collision.WasHitFromTopSide()) 
            {
                StartCoroutine(FadeAndDie());
            }
            else {
                GameManager.Instance.KillPlayer();
            }
        }

    }
    IEnumerator FadeAndDie()
    {
        if (GetComponent<Animator>() != null) 
            GetComponent<Animator>().enabled = false;
        
        if (_deathSpritePrefab != null) 
            Instantiate(_deathSpritePrefab, transform.position, transform.rotation);

        this.enabled = false;
        _rb.simulated = false;

        float alpha = 1;
        while (alpha > 0)
        {
            yield return null;
            alpha -= Time.deltaTime;
            _spriteRenderer.color = new Color(1, 1, 1, alpha);
        }
    }
}
