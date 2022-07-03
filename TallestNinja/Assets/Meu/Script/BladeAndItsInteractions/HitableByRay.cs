using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitableByRay : MonoBehaviour
{
    protected PlaySound playSound;
    protected bool hitByRay; //The game can update slow thus leading the game to double count points, if we apply this boolean it will stop double counting a single hit
    public virtual void HitByRayOrCollider()
    {
        playSound = gameObject.GetComponent<PlaySound>();
        playSound.PlaySoundFromList();
    }
    public virtual void TargetObject()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blade"))
        {
            HitByRayOrCollider();
            return;
        }
        if (other.gameObject.CompareTag("BottomFrame"))
        {
            TargetObject();
        }
    }
}
