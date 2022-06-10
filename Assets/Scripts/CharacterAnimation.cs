using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    Animator _animator;
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update() 
    {
        UpdateAnimator();
    }

    void UpdateAnimator()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
    }
}
