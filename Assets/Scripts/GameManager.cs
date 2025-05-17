using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text questionText;
    public Image questionImage;
    public TMP_Text feedbackText;
    public Button[] optionsButton;
    private int score = 0;

    [Header("Questions")]
    public List<QuestionData> questionDataList = new List<QuestionData>();
    private int currentQuestionIndex = 0;

    [Header("Background")]
    public BackgroundChanger backgroundChanger;

    [Header("Audio")]
    public AudioClip correctSound;
    public AudioClip wrongSound;

    private void Start()
    {
        backgroundChanger = GameObject.Find("BackgroundManager").GetComponent<BackgroundChanger>();
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        feedbackText.text = "";

        // Reseteaza fundalul pentru intrebarea curenta
        backgroundChanger.ResetBackground();

        QuestionData q = questionDataList[currentQuestionIndex];

        questionText.text = q.questionText;
        questionImage.sprite = q.questionImage;

        for (int i = 0; i < optionsButton.Length; i++)
        {
            optionsButton[i].GetComponentInChildren<TMP_Text>().text = q.options[i];
            int index = i;
            optionsButton[i].onClick.RemoveAllListeners();
            optionsButton[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    void CheckAnswer(int selectedIndex)
    {
        QuestionData q = questionDataList[currentQuestionIndex];

        if (selectedIndex == q.correctAnswerIndex)
        {
            feedbackText.text = "Correcto!";
            feedbackText.color = Color.green;
            score++;

            // Schimba fundalul la raspuns corect
            backgroundChanger.SetCorrectBackground();

            // Reda sunetul de raspuns corect
            if (correctSound != null)
                AudioSource.PlayClipAtPoint(correctSound, Camera.main.transform.position);
        }
        else
        {
            feedbackText.text = "Incorrecto! Inténtalo otra vez.";
            feedbackText.color = Color.red;

            // Reda sunetul de raspuns gresit
            if (wrongSound != null)
                AudioSource.PlayClipAtPoint(wrongSound, Camera.main.transform.position);
        }

        currentQuestionIndex++;

        if (currentQuestionIndex < questionDataList.Count)
        {
            Invoke(nameof(DisplayQuestion), 1.5f); // intarziere intre intrebari
        }
        else
        {
            Invoke(nameof(ShowFinalMessage), 1.5f); // afiseaza mesajul final
        }
    }

    void ShowFinalMessage()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("TotalQuestions", questionDataList.Count);
        SceneManager.LoadScene("EndScene");
    }
}
