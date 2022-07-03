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
    GameManager myGameManager;
    [SerializeField] ObjectPoolSpawner pooler;
    GameObject instantiated;
    Rigidbody[] rgbdOnSliced;
    [SerializeField] GameObject bottomGameObject;
    int bottomSpriteKey;
    private void Start()
    {
        slicedFruitKey = GetKeyFromPool(slicedFruitKey, slicedFruit);
        bottomSpriteKey = GetKeyFromPool(bottomSpriteKey, bottomGameObject);
        GetComponents();
        hitByRay = false;
    }
    void OnEnable() 
    {
        hitByRay = false;
    }
    int GetKeyFromPool(int key, GameObject objectToGetKey)
    {
        return pooler.GetKey(objectToGetKey);
    }
    void GetComponents()
    {
        myGameManager = FindObjectOfType<GameManager>();
    }
    public override void HitByRayOrCollider()
    {
        if(hitByRay)
        {
            return;
        }
        hitByRay = true;
        base.HitByRayOrCollider();
        InstantiateObjectFromPool(slicedFruitKey);
        SetPositionOfInstantiatedObjectFromPool();
        GetRigidbodyArrayOfInstantiatedObject();
        MakeAnExplosiveMotionForRigidbodies();
        instantiated.SetActive(true);
        UpdateScore();
        gameObject.SetActive(false);
    }
    public override void TargetObject()
    {
        //InstantiateObjectFromPool(bottomSpriteKey);
        //ResetPositionOfInstantiatedObjectFromPool();
        //StickGameObject();
        //instantiated.SetActive(true);
    }
    void InstantiateObjectFromPool(int key)
    {
        instantiated = pooler.GetObjectFromPool(key);
    }
    void ResetPositionOfInstantiatedObjectFromPool()
    {
        instantiated.transform.position = transform.position;
        instantiated.transform.rotation = Quaternion.identity;
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
        rgbdOnSliced = instantiated.transform.GetComponentsInChildren<Rigidbody>();
    }
    void MakeAnExplosiveMotionForRigidbodies()
    {
        foreach (Rigidbody rgdbd in rgbdOnSliced)
        {
            rgdbd.transform.rotation = Random.rotation;
            rgdbd.AddExplosionForce(Random.Range(force, force * forceRange), transform.position, 5f);
        }
    }
    void UpdateScore()
    {
        myGameManager.TriggerAlterationOfScore(pointAmount);
    }
}
