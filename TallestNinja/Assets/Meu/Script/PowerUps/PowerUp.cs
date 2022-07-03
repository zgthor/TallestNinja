using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : HitableByRay
{
    GameManager gameManager;
    
    public enum PowerUpLevel
    {
        Level0 = 0,
        Level1 = 1,
        Level2 = 2,
        Level3 = 3,
        Level4 = 4,
        Level5 = 5

    }
    
    [SerializeField] PowerUpLevel powerUpLevel;
    public override void HitByRayOrCollider()
    {
        if(hitByRay)
        {
            return;
        }
        hitByRay = true;
        gameManager = FindObjectOfType<GameManager>();
        PowerUpTaken();
        base.HitByRayOrCollider();
    }
    protected virtual void PowerUpTaken()
    {
        
    }

}
