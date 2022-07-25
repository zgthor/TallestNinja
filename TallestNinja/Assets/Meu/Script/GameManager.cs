using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Starter))]
[RequireComponent(typeof(PlayableArea))]
[RequireComponent(typeof(TimeManager))]
[RequireComponent(typeof(ShopManager))]
[RequireComponent(typeof(EventManager))]
[RequireComponent(typeof(LevelManager))]
[RequireComponent(typeof(ScoreManager))]
[RequireComponent(typeof(HealthManager))]
[RequireComponent(typeof(PointsManager))]
[RequireComponent(typeof(MySceneManager))]
public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager Instance;
    [HideInInspector] public static GameModeSettingsSO GameMode;
    public Spawner spawner;
    bool losingSequenceStarted;
    public float playableArea;

    private void Awake()
    {
        if(ThereIsNoGameManagerSingleton())
        {
            InstantiateGameManagerSingleton();
        }
        else
        {
            Destroy(this);
        }
        GetGameMode();
    }
    bool ThereIsNoGameManagerSingleton()
    {
        return Instance == null;
    }
    void InstantiateGameManagerSingleton()
    {
        Instance = this;
    }
    void GetGameMode()
    {
        GameMode = SelectedGameModeCarrier.Instance.GetSelectedGameMode();
    }
    void GameModeChosen(GameModeSettingsSO newGameMode)
    {
        GameMode = newGameMode;
    }
    public GameModeSettingsSO GetCurrentGameMode()
    {
        return GameMode;
    }
    public float GetPlayableArea()
    {
        return playableArea;
    }
}
