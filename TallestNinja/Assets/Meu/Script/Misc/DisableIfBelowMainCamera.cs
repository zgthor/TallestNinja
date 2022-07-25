using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfBelowMainCamera : MonoBehaviour
{
    [SerializeField] float offsetAsViewPort;
    [SerializeField] bool reportIfDisabled = false;
    Vector3 position;

     void Update()
    {
        GetObjectPosition();
        if(BelowMainCamera())
        {
            if(reportIfDisabled)
            {
                EventManager.Instance.FireEventOnFruitFallen();
            }
            gameObject.SetActive(false);
        }
    }
    void GetObjectPosition()
    {
        position = Camera.main.WorldToViewportPoint(gameObject.transform.position);
    }
    bool BelowMainCamera()
    {
        return position.y <= 0 - offsetAsViewPort;
    }

}
