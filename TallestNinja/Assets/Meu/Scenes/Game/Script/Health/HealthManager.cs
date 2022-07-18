using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int health;
    bool reported;
    public static HealthManager Instance;
    void Start()
    {
        if(ThereIsNoGameManagerSingleton())
        {
            InstantiateGameManagerSingleton();
        }
        else
        {
            Destroy(this);
        }
        UpdateToMaxHealth();
        DisplayHealth();
    }
    bool ThereIsNoGameManagerSingleton()
    {
        return Instance == null;
    }
    void InstantiateGameManagerSingleton()
    {
        Instance = this;
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
                GameManager.Instance.OutOfHealth();
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
        UIManager.Instance.UpdateHealthUI(health.ToString());
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
