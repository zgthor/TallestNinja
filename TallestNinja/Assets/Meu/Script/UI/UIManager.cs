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
    public void RemoveHighScoreText()
    {
        HighScoreText.text = "";
    }
    public void DisplayPoints(int Points)
    {
        pointsText.text = Points.ToString();
    }
    public void UpdateHealthUI(string health)
    {
        healthText.text = "HP: " + health;
    }
    public void DisableLivingUI()
    {
        AliveUI.SetActive(false);
    }
    public void StartLoosingSequence()
    {
        GameOverUI.SetActive(true);
    }
    public void UpdateLevel(int level)
    {
        currentLevelText.text = ("lvl: " + level);
    }
    public void UpdateCombo(int counter)
    {
        comboCounterText.text = (counter + " / " + maxCombo);
    }
}
