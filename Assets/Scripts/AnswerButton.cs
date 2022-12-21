using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public int Position = 0;
    public QuizCreator Parent;
    public TextMeshProUGUI AnswerText;
    public Button ThisButton;
    public void Init(string selection)
    {
        ThisButton.interactable = true;
        gameObject.SetActive(true);
        AnswerText.text = selection;
    }

    public void OnClick()
    {
        ThisButton.interactable = false;
        Parent.OnAnswerButtonClicked(Position);
    }
    private void OnValidate()
    {
        try {
            ThisButton = GetComponentInChildren<Button>();
            AnswerText = GetComponentInChildren<TextMeshProUGUI>();
        }
        catch (Exception e) {
            //ignored
        }
        try {
            Parent = FindObjectOfType<QuizCreator>();
        }
        catch (Exception e) {
            //ignored
        }
    }
}