using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public int Points { get;set; }
    public static PointsManager Instance;
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
        GetAllPoints();
        SavePoints();
    }
    bool ThereIsNoGameManagerSingleton()
    {
        return Instance == null;
    }
    void InstantiateGameManagerSingleton()
    {
        Instance = this;
    }
    private void GetAllPoints()
    {
        try
        {
            Points = PlayerPrefs.GetInt("Points");
        }
        catch
        {
            Points = 0;
        }
    }
    void SavePoints()
    {
        PlayerPrefs.SetInt("Points", Points);
    }
    public void ChangePointsAmountAndSaveIt(int amount)
    {
        ChangePointsAmount(amount);        
        SavePoints();
    }
    void ChangePointsAmount(int amount)
    {
        Points += amount;
    }
    public void TellUItoDisplayPoints()
    {
        UIManager.Instance.DisplayPoints(Points);
    }
}
