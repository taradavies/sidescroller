using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<PlayerMovementController>(out var player)) {
            GameManager.Instance.AddCoin();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
