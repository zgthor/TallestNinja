using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpecifiedTag : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjectsToDestroy;
    [SerializeField] GameManager gameManager;
    List<string> gameObjectsNames = new List<string>();
    string alteredName;
    [SerializeField]  GameObject objectToReport;
    void Start()
    {
        foreach(GameObject part in gameObjectsToDestroy)
        {
            gameObjectsNames.Add(part.name);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (ObjectCollidedWithPartToDestroy(other))
        {
            other.gameObject.SetActive(false);
            if(ObjectShouldBeReported(other))
            {
                ReportObjectDisabledness();
            }
        }
    }
    bool ObjectCollidedWithPartToDestroy(Collider collided)
    {
        foreach(string name in gameObjectsNames)
        {            
            if(name == collided.name)
            {
                return true;
            }
            alteredName = name + "(Clone)";
            if(alteredName == collided.name)
            {
                return true;
            }
        }
        return false;
    }
    bool ObjectShouldBeReported(Collider other)
    {
        return objectToReport.name == other.gameObject.name || objectToReport.name + "(Clone)" == other.gameObject.name;
    }
    void ReportObjectDisabledness()
    {
        gameManager.FruitFallen();
    }
}
