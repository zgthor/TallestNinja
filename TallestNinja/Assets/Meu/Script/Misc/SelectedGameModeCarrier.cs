using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedGameModeCarrier : MonoBehaviour
{
    [HideInInspector] public static SelectedGameModeCarrier Instance;
    GameModeSettingsSO selectedGameMode;
    private void Start()
    {
        if(ThereIsNoGameModeCarrierSingleton())
        {
            InstantiateGameModeCarrierSingleton();
        }
        else
        {
            Destroy(this);
        }
    }
    bool ThereIsNoGameModeCarrierSingleton()
    {
        return Instance == null;
    }
    void InstantiateGameModeCarrierSingleton()
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
