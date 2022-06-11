using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Collision2DExtensions
{
    public static bool WasHitByPlayer(this Collision2D collision) {
        return collision.collider.GetComponent<PlayerMovementController>() != null;
    }

    public static bool WasHitFromBottomSide(this Collision2D collision) {
        return collision.GetContact(0).normal.y > 0;
    }
}
