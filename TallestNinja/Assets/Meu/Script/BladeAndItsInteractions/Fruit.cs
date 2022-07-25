using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : HitableByRay
{
    [SerializeField] GameObject slicedFruit;
    int slicedFruitKey;
    [SerializeField] float force;
    [SerializeField] float forceRange;
    [SerializeField] int pointAmount;
    GameObject instantiated;
    Rigidbody[] rgbdOnSliced;
    [SerializeField] GameObject bottomGameObject;
    int bottomSpriteKey;
    private void Start()
    {
        slicedFruitKey = GetKeyFromPool(slicedFruit);
        bottomSpriteKey = GetKeyFromPool(bottomGameObject);
    }

    int GetKeyFromPool(GameObject objectToGetKey)
    {
        return ObjectPoolSpawner.Instance.GetKey(objectToGetKey);
    }
    public override void HitByRayOrCollider()
    {
        if(hitByRay)
        {
            return;
        }
        hitByRay = true;
        InstantiateObjectFromPool(slicedFruitKey);
        SetPositionOfInstantiatedObjectFromPool();
        GetRigidbodyArrayOfInstantiatedObject();
        MakeAnExplosiveMotionForRigidbodies();
        instantiated.SetActive(true);
        UpdateScore();
        base.HitByRayOrCollider();
    }
    public override void TargetObject()
    {
        //InstantiateObjectFromPool(bottomSpriteKey);
        //SetPositionOfInstantiatedObjectFromPool();
        //StickGameObject();
        //instantiated.SetActive(true);
    }
    void InstantiateObjectFromPool(int key)
    {
        instantiated = ObjectPoolSpawner.Instance.GetObjectFromPool(key);
    }
    void SetPositionOfInstantiatedObjectFromPool()
    {
        instantiated.transform.position = transform.position;
        instantiated.transform.rotation = transform.rotation;
    }
    void StickGameObject()
    {
        instantiated.transform.parent = gameObject.transform;
    }
    void GetRigidbodyArrayOfInstantiatedObject()
    {
        rgbdOnSliced = instantiated.transform.GetComponentsInChildren<Rigidbody>(true);
    }
    void MakeAnExplosiveMotionForRigidbodies()
    {
        foreach (Rigidbody rgdbd in rgbdOnSliced)
        {
            if(rgdbd != rgbdOnSliced[0])
            {
                rgdbd.transform.rotation = Random.rotation;
                rgdbd.AddExplosionForce(Random.Range(force, force * forceRange), transform.position, 5f);
            }
        }
    }
    void UpdateScore()
    {
        EventManager.Instance.FireEventOnAlterationOfScore(pointAmount);
        EventManager.Instance.FireEventOnFruitTouched();
    }
}
