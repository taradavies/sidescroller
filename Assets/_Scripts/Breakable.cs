using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    ParticleSystem _breakingFX;
    void Awake()
    {
        _breakingFX = GetComponent<ParticleSystem>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.WasHitByPlayer() && collision.WasHitFromBottomSide()) {
            _breakingFX.Play();
            DisableObject();
        }
    }

    private void DisableObject()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }
}
