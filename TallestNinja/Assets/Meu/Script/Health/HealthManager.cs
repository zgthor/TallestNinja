using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int health;
    bool reported;
    void Start()
    {
        UpdateToMaxHealth();
        DisplayHealth();
    }
    void OnEnable()
    {
        if(GameManager.Instance.GetCurrentGameMode().GetFruitsFallAsLoseCondition())
        {
            EventManager.Instance.OnFruitFallen += LoseHealth;
        }
        if(GameManager.Instance.GetCurrentGameMode().GetTouchBombsAsLoseCondition())
        {
            EventManager.Instance.OnBombTouched += LoseHealth;
        }
        EventManager.Instance.OnHealthPickedUp += HealthPickedUp;
    }
    void OnDisable()
    {
        if(GameManager.Instance.GetCurrentGameMode().GetFruitsFallAsLoseCondition())
        {
            EventManager.Instance.OnFruitFallen -= LoseHealth;
        }
        if(GameManager.Instance.GetCurrentGameMode().GetTouchBombsAsLoseCondition())
        {
            EventManager.Instance.OnBombTouched -= LoseHealth;
        }
        EventManager.Instance.OnHealthPickedUp -= HealthPickedUp;
    }
    void UpdateToMaxHealth()
    {
        health = maxHealth;
    }
    public void LoseHealth()
    {        
        LowerHP();
        if(OutOfHealth())
        {
            if(!HasBeenReported())
            {
                EventManager.Instance.FireEventOnLosingSequenceStart();
                ToggleThisVoidOff();
            }
        }
        else
        {
            DisplayHealth(); 
        }
    }
    void LowerHP()
    {
        health--;
    }
    public bool OutOfHealth()
    {
        return health<=0;
    }
    bool HasBeenReported()
    {
        return reported;
    }
    void DisplayHealth()
    {
        EventManager.Instance.FireEventOnHealthChange();
    }
    void ToggleThisVoidOff()
    {
        reported = true;
    }
    public void HealthPickedUp()
    {
        if(!HealthValueHigherThanMaxHealth())
        {
            health++;
            DisplayHealth();
        }
    }
    bool HealthValueHigherThanMaxHealth()
    {
        return health >= maxHealth;
    }
}
