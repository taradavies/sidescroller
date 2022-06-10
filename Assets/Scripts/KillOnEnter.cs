using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillOnEnter : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<PlayerMovementController>(out var player))
        {
            GameManager.Instance.KillPlayer();
        }
    }
}
