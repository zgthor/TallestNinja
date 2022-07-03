using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : PowerUp
{
    GameManager gameManager;
    protected override void PowerUpTaken()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.HealthPickUp();
    }
}
