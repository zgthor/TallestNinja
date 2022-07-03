using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelChanger : MonoBehaviour
{
    LevelManager levelManager;
    enum LevelChangeTrough
    {
        Time,
        AmountOfFruits,
        ItDoesNotChange
    }
    [Header("Settings")]
    [SerializeField]
    LevelChangeTrough levelChangeTrough;

    [Header("Trough Timer")]
    public float secondsBeforeLevelChange;

    [Header("Trough Fruits")]
    public float fruitsBeforeLevelChange;
    
    void Start()
    {
        levelManager = gameObject.GetComponent<LevelManager>();
        /*switch(levelChangeTrough)
        {
            case LevelChangeTrough.Time:
                gameObject.AddComponent<LevelChangeTroughTime>();
            break;

            case LevelChangeTrough.AmountOfFruits:
                gameObject.AddComponent<LevelChangeTroughFruits>();
            break;

        }*/
    }
    public void IncreaseLevel()
    {
        levelManager.IncreaseLevel();
    }
}
