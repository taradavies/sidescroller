using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    Animator _animator;
    IMove mover;
    void Awake()
    {
        _animator = GetComponent<Animator>();
        mover = GetComponent<IMove>();
    }

    void Update() 
    {
        UpdateAnimator();
    }

    void UpdateAnimator()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _animator.SetFloat("Speed", mover.Speed);
    }
}
