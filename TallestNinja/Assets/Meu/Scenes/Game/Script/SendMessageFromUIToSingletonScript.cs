using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessageFromUIToSingletonScript : MonoBehaviour
{
    public void SendGameMode(GameModeSettingsSO gameMode)
    {
        SelectedGameModeCarrier.Instance.ReceiveGameModeSettingsSO(gameMode);
    }
}
