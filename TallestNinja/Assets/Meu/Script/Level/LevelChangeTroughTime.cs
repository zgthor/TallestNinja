using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangeTroughTime : MonoBehaviour
{
    LevelChanger levelChanger;
    float levelTimer;
    void Start()
    {
        levelChanger = gameObject.GetComponent<LevelChanger>();
    }
    void Update()
    {        
        IncreaseTimer();
        if (TimerReachedLimit())
        {
            ResetTimer();
            levelChanger.IncreaseLevel();
        }
    }
    void IncreaseTimer()
    {
        levelTimer += Time.deltaTime;
    }
    bool TimerReachedLimit()
    {
        return GameManager.Instance.gameMode.GetSecondsBeforeLevelChange() <= levelTimer;
    }
    void ResetTimer()
    {
        levelTimer = 0;
    }
}
