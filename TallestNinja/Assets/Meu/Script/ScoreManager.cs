using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    int currentScore;
    int highScore;
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
        GetHighScore();
    }
    bool ThereIsNoGameManagerSingleton()
    {
        return Instance == null;
    }
    void InstantiateGameManagerSingleton()
    {
        Instance = this;
    }
    void GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
    }
    void OnEnable()
    {
        EventManager.Instance.OnAlterationOfScore += AlterScoreLogic;
    }
    void OnDisable()
    {
        EventManager.Instance.OnAlterationOfScore -= AlterScoreLogic;
    }
    void AlterScoreLogic(int newScore)
    {
        currentScore += newScore;
        AlterScoreDisplay();
        UpdateHighScoreIfNeeded();
    }
    void AlterScoreDisplay()
    {
        UIManager.Instance.UpdateScore(currentScore);
    }
    void UpdateHighScoreIfNeeded()
    {
        if(isCurrentScoreHigherThanHighestScore())
        {
            UpdateHighScoreValue();
            SaveNewHighScore();
        }
    }
    bool isCurrentScoreHigherThanHighestScore()
    {
        return highScore <= currentScore;
    }
    void UpdateHighScoreValue()
    {
        highScore = currentScore;
    }
    void SaveNewHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }
    public int GetCurrentScore()
    {
        return currentScore;
    }
}
