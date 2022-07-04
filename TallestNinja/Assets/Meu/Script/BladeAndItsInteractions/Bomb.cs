using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : HitableByRay
{
    override public void HitByRayOrCollider()
    {
        if(hitByRay)
        {
            return;
        }
        base.HitByRayOrCollider();
        hitByRay = true;
        LoseHP();        
    }
    void LoseHP()
    {
        GameManager.Instance.BombTapped();
    }

}
