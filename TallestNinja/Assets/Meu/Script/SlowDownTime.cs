using System.Collections;
using UnityEngine;

public class SlowDownTime : MonoBehaviour
{
    private void Awake()
    {
        UnpauseGame();
    }
    void UnpauseGame()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        if (!IsGamePause())
        {
            LowerTime();
        }
        else
        {
            PauseGame();
            DisableThisClass();
        }
    }
    bool IsGamePause()
    {
        return Time.timeScale <= 0.01f;
    }
    void LowerTime()
    {
        Time.timeScale -= 0.4f * Time.unscaledDeltaTime;
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void DisableThisClass()
    {
        this.enabled = false;
    }
}
