using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int health;
    [SerializeField] UIManager uIManager;
    GameManager gameManager;
    bool reported;
    void Start()
    {
        GetClassComponents();
        UpdateToMaxHealth();
        DisplayHealth(); 
    }
    void GetClassComponents()
    {
        gameManager = GetComponent<GameManager>();
        uIManager = GetComponent<UIManager>();
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
                gameManager.OutOfHealth();
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
        uIManager.UpdateHealthUI(health.ToString());
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
