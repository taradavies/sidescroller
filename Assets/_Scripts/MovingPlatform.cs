using UnityEngine;

public class MovingPlatform : Mover
{
    protected override void CollidedWithPlayer(PlayerMovementController player)
    {
        player.transform.SetParent(gameObject.transform);
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.TryGetComponent<PlayerMovementController>(out var player)) 
        {
            player.transform.SetParent(null);
        }
    }
}
