using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="GameMode", fileName = "New GameMode")]
public class GameModeSettingsSO : ScriptableObject
{
    public enum LevelChangeTrough
    {
        Time = 1,
        AmountOfFruits = 2,
        ItDoesNotChange = 3
    }

    [Header("Spawns")]
    [SerializeField] float secondsToSpawn;
    [SerializeField] float chanceOfBomb;


    [Header("LevelChanger")]
    [SerializeField] LevelChangeTrough levelChangeTrough;
    [SerializeField] float secondsBeforeLevelChange; //Implement a script editor or odin inspector in the future to make this more readable https://odininspector.com/attributes/hide-if-attribute https://answers.unity.com/questions/192895/hideshow-properties-dynamically-in-inspector.html
    [SerializeField] float fruitsBeforeLevelChange;


    [Header("GameModeTuner")]
    [SerializeField] bool allowSpecialLevels;
    [SerializeField] int comboRequirementForBoost;
    [SerializeField] float difficultyIncreasePerLevel;
    [SerializeField] int maxHealth;


    [Header("Lose HP if")]
    [SerializeField] bool FruitsFall;
    [SerializeField] bool TouchBombs;
    #region GetSpawns
    public float GetSpawnFrequency()
    {
        return secondsToSpawn;
    }
    public float GetChanceOfBomb()
    {
        return chanceOfBomb;
    }
    #endregion
    #region GetLevelChanger
    public LevelChangeTrough GetLevelChangeTrough()
    {
        return levelChangeTrough;
    }
    public float GetSecondsBeforeLevelChange()
    {
        return secondsBeforeLevelChange;
    }
    public float GetFruitsBeforeLevelChange()
    {
        return fruitsBeforeLevelChange;
    }
    #endregion
    #region GetGameModeTuner
    public bool GetAllowSpecialLevels()
    {
        return allowSpecialLevels;
    }
    public int GetComboRequirementForBoost()
    {
        return comboRequirementForBoost;
    }
    public float GetDifficultyIncreasePerLevel()
    {
        return difficultyIncreasePerLevel;
    }
    public int GetMaxHealth()
    {
        return maxHealth;
    }
    #endregion
    #region GetLoseIf
    public bool GetFruitsFallAsLoseCondition()
    {
        return FruitsFall;
    }
    public bool GetTouchBombsAsLoseCondition()
    {
        return TouchBombs;
    }
    #endregion
}
