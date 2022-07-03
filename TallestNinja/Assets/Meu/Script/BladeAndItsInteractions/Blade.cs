using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    Vector3 newVertices;
    Vector3 offset;
    Vector3 oldVertices;
    SphereCollider thisCollider;
    RaycastHit hit;
    int indexX;
    int indexY;
    int indexZ;
    [SerializeField]
    float minDistance;
    [SerializeField]
    float playAreaZVector = 0;
    [SerializeField]
    float verticesAccuracy = 7; // currently hard coded
    Vector3 mousePos;
    private void Start()
    {
        thisCollider = GetComponent<SphereCollider>();
        offset = thisCollider.bounds.max;
    }
    void Update()
    {
        UpdateBlade();        
    }
    /*void EnableDisableCollider()  Later use this as a power up
    {
        if((oldVertices - newVertices).magnitude * Time.deltaTime > minDistance * Time.deltaTime)
        {
            thisCollider.enabled = true;
        }
        else
        {
            thisCollider.enabled = false;
        }
    }*/
    void UpdateBlade()
    {        
        GetMousePosition();
        TransformMousePositionToWorldPosition();
        ResetMouseOffset();
        SetBladeToMousePosition();
        SetNewVerticesForRaycastAtThisPosition();
        TryToGetRayCollider();
        CastAllOldVerticesToNewVerticesAsALineWithOffsetAndTryToGetRayHit();
        UpdateVertices();
    }
    void GetMousePosition()
    {
        mousePos = Input.mousePosition;
    }
    void TransformMousePositionToWorldPosition()
    {
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }
    void ResetMouseOffset()
    {
        mousePos.z = playAreaZVector;
    }
    void SetBladeToMousePosition()
    {
        transform.position = mousePos;
    }
    void SetNewVerticesForRaycastAtThisPosition()
    {
        newVertices = transform.position;
    }
    void CastAllOldVerticesToNewVerticesAsALineWithOffsetAndTryToGetRayHit()
    {
        Debug.DrawLine(oldVertices , newVertices);
        Physics.Linecast(oldVertices, newVertices, out hit);
        TryToGetRayCollider();
        for (int i = 1; i < verticesAccuracy; i++)
        {
            switch (i)
            {
                case 1: // angle = 30 x = sen(angle) y = sen(angle + 30) z =  sen(angle + 60)
                    indexX = 1;
                    indexY = 1;
                    indexZ = 1;
                    break;
                case 2:
                    indexX = 1;
                    indexY = -1;
                    indexZ = 1;
                    break;
                case 3:
                    indexX = 1;
                    indexY = -1;
                    indexZ = -1;
                    break;
                case 4:
                    indexX = -1;
                    indexY = -1;
                    indexZ = -1;
                    break;
                case 5:
                    indexX = -1;
                    indexY = -1;
                    indexZ = 1;
                    break;
                case 6:
                    indexX = -1;
                    indexY = 1;
                    indexZ = -1;
                    break;
                default:
                    Debug.Log(i);
                    Debug.Log("Why default?");
                    break;
            }
            Debug.DrawLine(new Vector3(offset.x *indexX, offset.y * indexY, offset.z * indexZ) + oldVertices, newVertices + new Vector3(offset.x * indexX, offset.y * indexY, offset.z * indexZ));
            TryToGetRayCollider();
            Physics.Linecast(oldVertices + offset * i, newVertices + offset * i, out hit, 1 << LayerMask.NameToLayer("a"));
            TryToGetRayCollider();
        }
    }
    void UpdateVertices()
    {
        oldVertices = newVertices;
    }
    void TryToGetRayCollider()
    {
        if(hit.collider != null)
        {
            if (hit.collider.gameObject.TryGetComponent(out HitableByRay rayHit))
            {
                rayHit.HitByRayOrCollider();
            }
        }       
    }
}
