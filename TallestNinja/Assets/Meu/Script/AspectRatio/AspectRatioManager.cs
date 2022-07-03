using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatioManager : MonoBehaviour
{
    Camera newCamera;
    void Start()
    {
        newCamera = gameObject.GetComponent<Camera>();
        newCamera.aspect = 0.9f;
    }

}
