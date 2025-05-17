using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = " Quiz/Question")]
public class QuestionData : ScriptableObject
{
    public string questionText;
    public Sprite questionImage;
    public string[] options = new string[3];
    public int correctAnswerIndex;
}
