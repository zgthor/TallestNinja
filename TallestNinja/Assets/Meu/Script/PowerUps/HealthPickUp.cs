using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : PowerUp
{
    GameManager gameManager;
    protected override void PowerUpTaken()
    {
        EventManager.Instance.FireEventOnHealthPickedUp();
        base.PowerUpTaken();
    }
}
