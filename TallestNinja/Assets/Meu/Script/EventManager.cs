using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [HideInInspector] public static EventManager Instance;
    [HideInInspector] public event Action OnGameStart;
    [HideInInspector] public event Action OnFruitFallen;
    [HideInInspector] public event Action OnHealthPickedUp;
    [HideInInspector] public event Action OnOutOfHealth;
    [HideInInspector] public event Action OnTimerTicked;
    [HideInInspector] public event Action OnFruitSpawned;
    [HideInInspector] public event Action OnBombSpawned;
    [HideInInspector] public event Action<int> OnAlterationOfScore;
    [HideInInspector] public event Action OnBombTouched;
    [HideInInspector] public event Action OnFruitTouched;
    [HideInInspector] public event Action OnHighScoreReached;
    [HideInInspector] public event Action OnLosingSequenceStart;
    [HideInInspector] public event Action OnHealthChange;
    [HideInInspector] public event Action<int> OnLevelChange;
    [HideInInspector] public event Action OnComboThresholdReached;

    void Awake()
    {
        if(ThereIsNoEventManagerSingleton())
        {
            InstantiateEventManagerSingleton();
        }
        else
        {
            Destroy(this);
        }
    }
    bool ThereIsNoEventManagerSingleton()
    {
        return Instance == null;
    }
    void InstantiateEventManagerSingleton()
    {
        Instance = this;
    }
    void IfEventNotNullFireIt(Action action)
    {
        if(IsEventNull(action))
        {
            action();
        }
    }
    bool IsEventNull(Action action)
    {
        return action != null;
    }
    public void FireEventOnGameStart()
    {
        IfEventNotNullFireIt(OnGameStart);
    }
    public void FireEventTimeTick()
    {
        IfEventNotNullFireIt(OnTimerTicked);
    }
    public void FireEventOnFruitFallen()
    {
        IfEventNotNullFireIt(OnFruitFallen);
    }
    public void FireEventOnBombTouched()
    {
        IfEventNotNullFireIt(OnBombTouched);
    }
    public void FireEventOnFruitTouched()
    {
        IfEventNotNullFireIt(OnFruitTouched);
    }
    public void FireEventOnHealthPickedUp()
    {
        IfEventNotNullFireIt(OnHealthPickedUp);
    }
    public void FireEventOnAlterationOfScore(int points)
    {
        if(OnAlterationOfScore != null)
        {
            OnAlterationOfScore(points);
        }
    }
    public void FireEventNewOnHighScoreReached()
    {
        IfEventNotNullFireIt(OnHighScoreReached);
    }
    public void FireEventOnLosingSequenceStart()
    {
        IfEventNotNullFireIt(OnLosingSequenceStart);
    }
    public void FireEventOnFruitSpawned()
    {
        OnFruitSpawned?.Invoke();
    }
    public void FireEventOnHealthChange()
    {
        IfEventNotNullFireIt(OnHealthChange);
    }
    public void FireEventOnLevelChange(int level)
    {
        if(OnLevelChange != null)
        {
            OnLevelChange(level);
        }
    }
    public void FireEventOnComboThresholdReached()
    {
        IfEventNotNullFireIt(OnComboThresholdReached);
    }
}
