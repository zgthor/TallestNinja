using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchColliderAcrossScreenWidth : MonoBehaviour
{
    private BoxCollider boxCollider;
    Vector3 bottomLeftMostViewport;
    Vector3 bottomRightMostViewport;
    float distance;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        bottomLeftMostViewport = Camera.main.ViewportToWorldPoint(Vector2.zero);
        bottomRightMostViewport = Camera.main.ViewportToWorldPoint(new Vector2 (0,1));
        distance = Vector3.Distance(bottomLeftMostViewport,bottomRightMostViewport);
        boxCollider.size = new Vector3(distance,1,1);
    }
}
