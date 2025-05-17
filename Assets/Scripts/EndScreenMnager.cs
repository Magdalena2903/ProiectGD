using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreenMnager : MonoBehaviour
{
    public TMP_Text scoreText;
    public Button restartButton;

    [Header("Backgrounds")]
    public Image backgroundImage;
    public Sprite goodScoreBackground;
    public Sprite lowScoreBackground;

    [Header("Balloon Spawner")]
    public GameObject balloonSpawnerPrefab;

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("Score", 0);
        int totalQuestions = PlayerPrefs.GetInt("TotalQuestions", 0);

        scoreText.text = $"Tu puntuación: {finalScore} / {totalQuestions}";

        // SETARE FUNDAL SI BALOANE
        if (finalScore >= 5)
        {
            backgroundImage.sprite = goodScoreBackground;

            // Instanțiază baloanele în Canvas dacă scorul este bun
            if (balloonSpawnerPrefab != null)
            {
                Canvas canvas = FindFirstObjectByType<Canvas>();
                if (canvas != null)
                {
                    Instantiate(balloonSpawnerPrefab, canvas.transform);
                }
            }
        }
        else
        {
            backgroundImage.sprite = lowScoreBackground;
        }

        restartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainMenu");
        });
    }
}
