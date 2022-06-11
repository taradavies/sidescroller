using UnityEngine;

public class MovingPlatform : Mover
{
    protected override void CollidedWithPlayer(Collision2D collision)
    {
        if (transform.position.y < collision.transform.position.y)
            collision.transform.SetParent(transform);
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.WasHitByPlayer()) 
        {
            collision.transform.SetParent(null);
        }
    }
}
