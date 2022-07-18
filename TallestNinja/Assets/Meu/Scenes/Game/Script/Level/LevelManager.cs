using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [HideInInspector] public int currentLevel = 1;
    float DifficultyIncreaseInPercentage;
    public enum levelType
    {
        FastAndFurious,
        SlowAndBulky,
        Normal,
        MineField,
    }

    public static LevelManager Instance;
    void Start()
    {
        if(ThereIsNoGameManagerSingleton())
        {
            InstantiateGameManagerSingleton();
        }
        else
        {
            Destroy(this);
        }
        CalculateDifficultyIncreasePercentage();
    }
    bool ThereIsNoGameManagerSingleton()
    {
        return Instance == null;
    }
    void InstantiateGameManagerSingleton()
    {
        Instance = this;
    } 
    void CalculateDifficultyIncreasePercentage()
    {
        DifficultyIncreaseInPercentage = 100 / GameManager.Instance.gameMode.GetSecondsBeforeLevelChange();
    }
    public void IncreaseLevel()
    {
        currentLevel++;
        MakeLevelHarder();
        GameManager.Instance.LevelChanged(currentLevel);
    } 
    void MakeLevelHarder()
    {
        GameManager.Instance.spawner.DecreaseTimeToSpawnBy(GameManager.Instance.spawner.timeToSpawn / DifficultyIncreaseInPercentage);
    }
}
