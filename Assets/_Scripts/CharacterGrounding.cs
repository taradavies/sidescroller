using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [Header("---Ground Check---")]
    [SerializeField] Transform _groundCheck;
    [SerializeField] float _distanceFromGround;
    [SerializeField] LayerMask _groundMask;

    public bool IsGrounded { get; private set; }

    void Update() 
    {
        UpdateIsGrounded();
    }

    void UpdateIsGrounded()
    {
        var groundSensor = Physics2D.OverlapCircle(_groundCheck.position, _distanceFromGround, _groundMask);
        IsGrounded = groundSensor != null;
    }
}
