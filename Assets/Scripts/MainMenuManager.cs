using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    void Start()
    {
        startButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("GameScene");
        });

        exitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}