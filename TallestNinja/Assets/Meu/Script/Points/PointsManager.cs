using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    int points;
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
    void OnEnable()
    {
        EventManager.Instance.OnLosingSequenceStart += ChangePointsAmount;
        EventManager.Instance.OnLosingSequenceStart += SavePoints;
    }
    void OnDisable()
    {
        EventManager.Instance.OnLosingSequenceStart -= ChangePointsAmount;
        EventManager.Instance.OnLosingSequenceStart -= SavePoints;
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
            points = PlayerPrefs.GetInt("Points");
        }
        catch
        {
            points = 0;
        }
    }
    void SavePoints()
    {
        PlayerPrefs.SetInt("Points", points);
    }
    void ChangePointsAmount()
    {
        points += ScoreManager.Instance.GetCurrentScore();
    }
    public int GetPoints()
    {
        return points;
    }
}
