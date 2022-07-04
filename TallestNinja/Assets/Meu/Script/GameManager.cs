using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public int score;
    public int highScore;
    TimeManagementClass timeManagementClass;
    PointsManager pointsManager;
    UIManager uIManager;
    [SerializeField] GameObject blade;
    public static GameManager Instance;
    HealthManager healthManager;
    bool losingSequenceStarted;
    ComboCounter comboCounter;
    enum GameMode
    {
        BetterDeadThanRed,
        NoFallenFruit
    }
    [SerializeField] GameMode gameMode;
    [SerializeField] Spawner spawner;    

    private void Start()
    {
        GetClassComponents();
        GetHighScore();
        if(ThereIsNoGameManagerSingleton())
        {
            InstantiateGameManagerSingleton();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
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
        pointsManager = GetComponent<PointsManager>();
        timeManagementClass = GetComponent<TimeManagementClass>();
        uIManager = GetComponent<UIManager>();
        healthManager = GetComponent<HealthManager>();
        comboCounter = GetComponent<ComboCounter>();
    }
    void GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
    }
    public void TriggerAlterationOfScore(int alteredPoints)
    {
        comboCounter.FruitHit();
        AlterScore(alteredPoints);
        ShowScoreIncreaseOnUI();
        if(isCurrentScoreHigherThanHighestScore())
        {
            UpdateHighScoreValue();
            SaveNewHighScore();
            uIManager.RemoveHighScoreText();
        }
    }
    void AlterScore(int alteredPoints)
    {
        score += alteredPoints;
    }
    void ShowScoreIncreaseOnUI()
    {
        uIManager.UpdateScore(score);
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
        uIManager.StartLoosingSequence();
        pointsManager.TellUItoDisplayPoints();
        DisableBlade();
        uIManager.DisableLivingUI();
    }
    void EnableSlowTime()
    {
        timeManagementClass.enabled = true;
    }
    void AddScoreToPoints()
    {
        pointsManager.ChangePointsAmountAndSaveIt(score);
    }

    void DisableBlade()
    {
        blade.SetActive(false);
    }
    public void FruitFallen()
    {
        if(gameMode == GameMode.NoFallenFruit)
        {
            healthManager.LoseHealth();
        }
        ResetCombo();
    }
    void ResetCombo()
    {
        comboCounter.ComboLost();
    }
    public void BombTapped()
    {
        if(gameMode == GameMode.BetterDeadThanRed)
        {
            healthManager.LoseHealth();
        }
        ResetCombo();
    }
    public void OutOfHealth()
    {
        StartLoosingSequence();
    }
    public void LevelChanged(int level) 
    {
        
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
        healthManager.HealthPickedUp();
    }
}
