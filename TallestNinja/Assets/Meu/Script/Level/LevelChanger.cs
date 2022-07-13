using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelChanger : MonoBehaviour
{    
    void Start()
    {
        switch(((int)GameManager.Instance.gameMode.GetLevelChangeTrough()))
        {
            case 1: // change trough Timer
                gameObject.AddComponent<LevelChangeTroughTime>();
            break;

            case 2:// change trough fruit Amount
                gameObject.AddComponent<LevelChangeTroughFruits>();
            break;
        }
    }
    public void IncreaseLevel()
    {
        LevelManager.Instance.IncreaseLevel();
    }
}
