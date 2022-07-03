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
    int highScore;
    List<GameObject> UIPanels = new List<GameObject>();

    private void Start()
    {
        CleanScreenFromUIClutter();
        GetHighScore();
        DisplayHighScore();
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
}
