using UnityEngine;

public class MovingPlatform : Mover
{
    protected override void CollidedWithPlayer(Collision2D collision)
    {
        var player = collision.collider.GetComponent<PlayerMovementController>();

        if (transform.position.y < player.transform.position.y)
            player.transform.SetParent(transform);
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.TryGetComponent<PlayerMovementController>(out var player)) 
        {
            player.transform.SetParent(null);
        }
    }
}
