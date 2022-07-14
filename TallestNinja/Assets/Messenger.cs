using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messenger : MonoBehaviour
{
    public static Messenger Instance;
    public static GameObject GameObjectInstance;

    void Start()
    {
        if(ThereIsNoGameManagerSingleton())
        {
            InstantiateThisAsTheSingletonGameObject();
        }
        else
        {
            Destroy(gameObject);
            Destroy(this);
        }
    }
    bool ThereIsNoGameManagerSingleton()
    {
        return Instance == null;
    }
    void InstantiateThisAsTheSingletonGameObject()
    {
        Instance = this;
    }
    public GameObject GetMessengerGameObject()
    {
        return gameObject;
    }
}
