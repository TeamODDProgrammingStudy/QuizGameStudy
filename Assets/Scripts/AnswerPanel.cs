using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using TMPro;
using UnityEngine;

public class AnswerPanel : UIWindow
{
    [SerializeField] private TextMeshProUGUI _resultText;
    [SerializeField] private TextMeshProUGUI _answerDescriptionText;
    [SerializeField] private TextMeshProUGUI _answerText;
    [TextArea][SerializeField] private string _successText = "";
    [TextArea][SerializeField] private string _failedText = "";
    [SerializeField]private bool _isAnswer = false;
    public void SetIsAnswer(bool isAnswer)
    {
        _isAnswer = isAnswer;
    }
    public void Open(Quiz quiz)
    {
        _resultText.text = _isAnswer ? _successText : _failedText;
        //수정을 위해 아래와 같이 작성
        _answerDescriptionText.text = $"{quiz.Selection[quiz.Answer-1]}" ;
        _answerText.text = $"정답은 <color=red>{quiz.Answer}번</color> 입니다.";
        base.Open();
    }
}
