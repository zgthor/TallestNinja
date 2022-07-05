using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfChildrenInvisibleAndResetIt : MonoBehaviour
{ // in the future switch this to an event that will be fired from a event manager class which this class will be subscribed to
// in the future find a way to separate this class in more parts
    Transform[] transformArray;
    List <Transform> transformList = new List<Transform>();
    static List <Vector3> originalPositions = new List<Vector3>();
    Rigidbody[] rigidBodyArray;
    [SerializeField] float timeToDisable;
    float timerCountDown;
    
    private void Awake() 
    {
        GetTransforms();
    }
    private void OnEnable() 
    {
        ResetTimer();
        EnableChildren();
    }
        void GetTransforms()
    {
        transformArray = gameObject.GetComponentsInChildren<Transform>();
        foreach(Transform child in transformArray)
        {
            if(child.gameObject != gameObject)
            {
                transformList.Add(child);
            }
        }
        rigidBodyArray = gameObject.GetComponentsInChildren<Rigidbody>();
        for(int i = 0; i <= gameObject.transform.childCount -1; i++)
        {            
            originalPositions.Add(transformList[i].localPosition);   
        }        
    }

    void ResetTimer()
    {
        timerCountDown = timeToDisable;
    }
    void EnableChildren()
    {
        foreach(Transform child in transformList)
        {
            child.gameObject.SetActive(true);
        }
    }
    private void Update() 
    {
        timerCountDown -= Time.deltaTime;
        if(timerCountDown <= 0)
        {
            ResetTimer();
            if(!ActiveObjectsInTransformArray())
            {
                gameObject.SetActive(false);
            }
        }
    }
    bool ActiveObjectsInTransformArray()
    {
       foreach (Transform item in transformList)
       {
        if(item.gameObject.activeInHierarchy)
        {
            return true;
        }
       }
       return false;
    }
    void OnDisable()
    {
        ResetRigidBodyVelocity();        
        ResetTimer();
        ResetPositions();
    }
    void ResetRigidBodyVelocity()
    {
        foreach(Rigidbody child in rigidBodyArray)
        {
            child.velocity = Vector3.zero;
        }
    }   
        void ResetPositions()
    {
        for(int i = 0; i <= transformList.Count -1; i++)
        {
            transformList[i].localPosition = originalPositions[i];
            transformList[i].localRotation = Quaternion.identity;
        }
    }
}
