using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int currentLevel;
    [SerializeField] float DifficultyIncreaseInPercentage;
    [SerializeField] Spawner spawner;
    public enum levelType
    {
        FastAndFurious,
        SlowAndBulky,
        Normal,
        MineField,

    }
    [SerializeField] GameManager gameManager;

    void Start()
    {
        CalculateDifficultyIncreasePercentage();
    }
    void CalculateDifficultyIncreasePercentage()
    {
        DifficultyIncreaseInPercentage = 100 / DifficultyIncreaseInPercentage;
    }
    public void IncreaseLevel()
    {
        currentLevel++;
        MakeLevelHarder();
        //gameManager.LevelChanged(currentLevel);
    } 
    void MakeLevelHarder()
    {
        spawner.timeToSpawn -= spawner.timeToSpawn / DifficultyIncreaseInPercentage;
    }
}
