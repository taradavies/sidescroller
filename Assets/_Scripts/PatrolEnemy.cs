using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : Mover
{
    protected override void CollidedWithPlayer(Collision2D collision)
    {
        GameManager.Instance.KillPlayer();
    }
}
