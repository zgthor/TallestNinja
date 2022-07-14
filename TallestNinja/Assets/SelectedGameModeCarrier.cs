using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedGameModeCarrier : MonoBehaviour
{
    [HideInInspector] public static SelectedGameModeCarrier Instance;
    GameModeSettingsSO selectedGameMode;
    private void Start()
    {
        if(ThereIsNoGameManagerSingleton())
        {
            InstantiateGameManagerSingleton();
        }
        else
        {
            Destroy(this);
        }
    }
    bool ThereIsNoGameManagerSingleton()
    {
        return Instance == null;
    }
    void InstantiateGameManagerSingleton()
    {
        Instance = this;
    }
    public void ReceiveGameModeSettingsSO(GameModeSettingsSO newGameMode)
    {
        selectedGameMode = newGameMode;
    }
    public GameModeSettingsSO GetSelectedGameMode()
    {
        return selectedGameMode;
    }
}
