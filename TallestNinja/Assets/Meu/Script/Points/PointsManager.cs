using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public int Points { get;set; }
    UIManager uIManager;
    private void Start()
    {
        GetUIComponent();
        GetAllPoints();
        SavePoints();
    }
    void GetUIComponent()
    {
        uIManager = gameObject.GetComponent<UIManager>();
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
        uIManager.DisplayPoints(Points);
    }
}
