using UnityEngine;
using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour
{
    public Image backgroundImage;
    public Sprite defaultBackground;
    public Sprite correctAnswerBackground;

    public void SetCorrectBackground()
    {
        backgroundImage.sprite = correctAnswerBackground;
    }

    public void ResetBackground()
    {
        backgroundImage.sprite = defaultBackground;
    }
}
