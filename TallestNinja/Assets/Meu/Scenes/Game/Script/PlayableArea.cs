using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableArea : MonoBehaviour
{
    public float playableAreaZ;
    public Vector3 GetMaximumPlayableArea()
    {
        return Camera.main.ViewportToWorldPoint(new Vector2(1,1));
    }
    public Vector3 GetMinimumPlayableArea()
    {
        return Camera.main.ViewportToWorldPoint(new Vector2(0,0));
    }
    public float GetPlayableAreaZ()
    {
        return playableAreaZ;
    }
}
