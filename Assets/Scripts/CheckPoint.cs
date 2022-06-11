using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool PassedCheckPoint { get; private set; }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<PlayerMovementController>(out var player)) {
            PassedCheckPoint = true;
        }
    }
}
