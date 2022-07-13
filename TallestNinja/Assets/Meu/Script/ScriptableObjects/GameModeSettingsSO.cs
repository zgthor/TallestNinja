using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="waveConfig", fileName = "New Wave Config")]
public class GameModeSettingsSO : ScriptableObject
{
    [Header("Enable/Disable Spawns")]
    [SerializeField] bool canBombsSpawn,canFruitsSpawn;
    [Header("GameModeTuner")]
    [SerializeField] int comboRequirementForBoost;
    [Header("Lose variables")]
    [SerializeField] bool canFruitsFall;
    [SerializeField] bool canTouchBombs;

    public int GetComboRequirementForBoost()
    {
        return comboRequirementForBoost;
    }
    public bool GetCanFruitsFall()
    {
        return canFruitsFall;
    }
    public bool GetWillBombSpawn()
    {
        return canFruitsFall;
    }
}
