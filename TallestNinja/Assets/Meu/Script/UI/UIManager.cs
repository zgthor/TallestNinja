using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject AliveUI;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI HighScoreText;
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI currentLevelText;
    [SerializeField] TextMeshProUGUI comboCounterText;
    [SerializeField] TextMeshProUGUI finalScore;
    int highScore;
    int maxCombo;
    List<GameObject> UIPanels = new List<GameObject>();

    public static UIManager Instance;
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
        CleanScreenFromUIClutter();
        GetHighScore();
        DisplayHighScore();
    }
    private void OnEnable() 
    {
        EventManager.Instance.OnHighScoreReached += RemoveHighScoreText;
        EventManager.Instance.OnLosingSequenceStart += StartLoosingSequence;
        EventManager.Instance.OnLevelChange += UpdateLevel;
    }
    void OnDisable()
    {
        EventManager.Instance.OnHighScoreReached -= RemoveHighScoreText;
        EventManager.Instance.OnLosingSequenceStart -= StartLoosingSequence;
        EventManager.Instance.OnLevelChange -= UpdateLevel;
    }
    bool ThereIsNoGameManagerSingleton()
    {
        return Instance == null;
    }
    void InstantiateGameManagerSingleton()
    {
        Instance = this;
    }
    void CleanScreenFromUIClutter()
    {
        foreach(GameObject panel in UIPanels)
        {
            panel.SetActive(false);
        }
    }
    private void GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
    }
    void DisplayHighScore()
    {
        HighScoreText.text = "Best: " + highScore.ToString();
    }
    public void ReceiveMaxCombo(int max)
    {
        maxCombo = max;
        UpdateCombo(0);
    }
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    void RemoveHighScoreText()
    {
        HighScoreText.text = "";
    }
    void DisplayPoints()
    {
        pointsText.text = PointsManager.Instance.GetPoints().ToString();
    }
    void UpdateHealthUI(string health)
    {
        healthText.text = "HP: " + health;
    }
    void DisableLivingUI()
    {
        AliveUI.SetActive(false);
    }
    void StartLoosingSequence()
    {
        DisableLivingUI();
        GameOverUI.SetActive(true);
        DisplayFinalScore();
        DisplayPoints();
    }
    void UpdateLevel(int level)
    {
        currentLevelText.text = ("lvl: " + level);
    }
    public void UpdateCombo(int counter)
    {
        comboCounterText.text = (counter + " / " + maxCombo);
    }
    void DisplayFinalScore()
    {
        finalScore.text = "Final Score: " + ScoreManager.Instance.GetCurrentScore();
    }
}
