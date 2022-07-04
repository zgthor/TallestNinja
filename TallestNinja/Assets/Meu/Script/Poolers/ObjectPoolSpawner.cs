using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolSpawner : MonoBehaviour
{
    [SerializeField] private int poolSize = 100;
    static List<List<GameObject>> listOfLists = new List<List<GameObject>>();
    static List<GameObject> gameObjectList = new List<GameObject>();
    static List<string> gameObjectsNameList = new List<string>();
    static GameObject parentObject;
    int key = 50;
    GameObject currentGameObjectUndergoingKeyEvaluation;
    string currentGameObjectsNameUndergoingKeyEvaluation;
    GameObject newObject;
    public static ObjectPoolSpawner Instance;
    void Awake()
    {
        if(ThereIsNoGameManagerSingleton())
        {
            InstantiateGameManagerSingleton();
        }
        else
        {
            Destroy(this);
            return;
        }
        CreateLists();
        WipeLists();
        CreateParentObjectForPools();
    }
    void CreateLists()
    {
        listOfLists = new List<List<GameObject>>();
        gameObjectList = new List<GameObject>();
        gameObjectsNameList = new List<string>();
    }
    void WipeLists()
    {
        listOfLists.Clear();
        gameObjectList.Clear();
        gameObjectsNameList.Clear();
    }
    void CreateParentObjectForPools()
    {
        parentObject = new GameObject("Pool");
    }
    bool ThereIsNoGameManagerSingleton()
    {
        return Instance == null;
    }
    void InstantiateGameManagerSingleton()
    {
        Instance = this;
    }
    public int GetKey(GameObject importedGO)
    {
        GetGameObjectToEvaluate(importedGO);
        if (IsGameObjectImplemented())
        {
            return key;
        }
        ImplementKey();
        return key;
    }
    void GetGameObjectToEvaluate(GameObject importedGO)
    {
        currentGameObjectUndergoingKeyEvaluation = importedGO;
        currentGameObjectsNameUndergoingKeyEvaluation = importedGO.name;
    }
    bool IsGameObjectImplemented()
    {
        for (key = 0; key < gameObjectsNameList.Count; key++)
        {
            if (IsThereOneOrMoreGameObjectInNameList() && DoTheNamesMatch())
            {
                if (DoTheGameObjectsMatch())
                {
                    return true;
                }
            }
        }
        return false;
    }
    bool IsThereOneOrMoreGameObjectInNameList()
    {
        return gameObjectsNameList.Count >= 1 && name == gameObjectsNameList[key];
    }
    bool DoTheNamesMatch()
    {
        return currentGameObjectsNameUndergoingKeyEvaluation == gameObjectsNameList[key];
    }
    bool DoTheGameObjectsMatch()
    {
        return currentGameObjectUndergoingKeyEvaluation == gameObjectList[key] && gameObjectList[key] != null;
    }
    void ImplementKey()
    {
        CreateList();
        GenerateKey();
        AddGameObjectsToTheLists();
        FillPool();
    }
   
    void CreateList()
    {
        listOfLists.Add(new List<GameObject>());
    }
    void GenerateKey()
    {
        key = listOfLists.Count -1;
    }
    void AddGameObjectsToTheLists()
    {
        gameObjectList.Add(currentGameObjectUndergoingKeyEvaluation);
        gameObjectsNameList.Add(currentGameObjectsNameUndergoingKeyEvaluation);
    }
    void FillPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            newObject = Instantiate(currentGameObjectUndergoingKeyEvaluation);
            newObject.SetActive(false);
            try
            {
                newObject.transform.parent = parentObject.transform;
            }
            catch
            {
            }
            AddGameObjectToItsListPosition();
        }
    }
    void AddGameObjectToItsListPosition()
    {
        listOfLists[listOfLists.Count - 1].Add(newObject);
    }
    public GameObject GetObjectFromPool(int usedKey)
    {
        for (int i = 0; i < listOfLists[usedKey].Count; i++)
        {
            if (!listOfLists[usedKey][i].activeInHierarchy)
            {
                return listOfLists[usedKey][i];
            }
        }
        return AddObjectToThePool(usedKey);
    }
    GameObject AddObjectToThePool(int usedKey)
    {
        GameObject newObject = Instantiate(gameObjectList[usedKey]);
        newObject.SetActive(false);
        newObject.transform.parent = parentObject.transform;

        listOfLists[usedKey].Add(newObject);
        return newObject;
    }
}
