using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    [HideInInspector] public int score;
    [HideInInspector] public int highScore;
    public SlowDownTime slowDownTime;
    public GameObject blade;
    public static GameManager Instance;
    public GameModeSettingsSO gameMode;
    public Spawner spawner;
    bool losingSequenceStarted;

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
        GetClassComponents();
        GetHighScore();
    }
    void GameModeChosen(GameModeSettingsSO newGameMode)
    {
        gameMode = newGameMode;
    }
    bool ThereIsNoGameManagerSingleton()
    {
        return Instance == null;
    }
    void InstantiateGameManagerSingleton()
    {
        Instance = this;
    }
    void GetClassComponents()
    {
        slowDownTime = GetComponent<SlowDownTime>();
    }
    void GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
    }
    public void TriggerAlterationOfScore(int alteredPoints)
    {
        ComboCounter.Instance.FruitHit();
        AlterScore(alteredPoints);
        ShowScoreIncreaseOnUI();
        if(isCurrentScoreHigherThanHighestScore())
        {
            UpdateHighScoreValue();
            SaveNewHighScore();
            UIManager.Instance.RemoveHighScoreText();
        }
    }
    void AlterScore(int alteredPoints)
    {
        score += alteredPoints;
    }
    void ShowScoreIncreaseOnUI()
    {
        UIManager.Instance.UpdateScore(score);
    }
    bool isCurrentScoreHigherThanHighestScore()
    {
        return highScore <= score;
    }
    void UpdateHighScoreValue()
    {
        highScore = score;
    }
    void SaveNewHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    public void StartLoosingSequence()
    {
        EnableSlowTime();
        AddScoreToPoints();
        UIManager.Instance.StartLoosingSequence();
        PointsManager.Instance.TellUItoDisplayPoints();
        DisableBlade();
        UIManager.Instance.DisableLivingUI();
    }
    void EnableSlowTime()
    {
        slowDownTime.enabled = true;
    }
    void AddScoreToPoints()
    {
        PointsManager.Instance.ChangePointsAmountAndSaveIt(score);
    }

    void DisableBlade()
    {
        blade.SetActive(false);
    }
    public void FruitFallen()
    {
        if(gameMode.GetFruitsFallAsLoseCondition())
        {
            HealthManager.Instance.LoseHealth();
        }
        ResetCombo();
    }
    void ResetCombo()
    {
        ComboCounter.Instance.ComboLost();
    }
    public void BombTapped()
    {
        if(gameMode.GetTouchBombsAsLoseCondition())
        {
            HealthManager.Instance.LoseHealth();
        }
        ResetCombo();
    }
    public void OutOfHealth()
    {
        StartLoosingSequence();
    }
    public void LevelChanged(int level) 
    {
        UIManager.Instance.UpdateLevel(level);
    }
    public void FruitSpawned()
    {

    }
    public void AskForAPowerUp()
    {
        spawner.SpawnAPowerUp();
    }
    public void HealthPickUp()
    {
        HealthManager.Instance.HealthPickedUp();
    }
}
