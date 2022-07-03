using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : HitableByRay
{
    GameManager gameManager;
    GameObject gameManagerGameObject;
    override public void HitByRayOrCollider()
    {
        if(hitByRay)
        {
            return;
        }
        base.HitByRayOrCollider();
        hitByRay = true;
        FindGameManagerGameObject();
        FindGameManagerComponent();
        LoseHP();        
    }
    void FindGameManagerGameObject()
    {
        gameManagerGameObject = GameObject.FindGameObjectWithTag("GameManager");
    }
    void FindGameManagerComponent()
    {
        gameManager = gameManagerGameObject.GetComponent<GameManager>();
    }
    void LoseHP()
    {
        gameManager.BombTapped();
    }

}
