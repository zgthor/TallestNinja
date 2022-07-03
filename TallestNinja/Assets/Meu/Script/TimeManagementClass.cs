using System.Collections;
using UnityEngine;

public class TimeManagementClass : MonoBehaviour
{
    TimeManagementClass thisClass;
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
            GetThisClassReference();
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
    void GetThisClassReference()
    {
        thisClass = gameObject.GetComponent<TimeManagementClass>();
    }
    void DisableThisClass()
    {
        thisClass.enabled = false;
    }
}
