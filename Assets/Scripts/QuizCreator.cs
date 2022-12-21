using System;
using System.Collections.Generic;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class QuizCreator : MonoBehaviour
{
    [SerializeField] private int _maxLifeCount = 2;
    [SerializeField] private int _currentLifeCount;
    [SerializeField] private TextMeshProUGUI _question;
    [SerializeField] private AnswerButton[] _answerButtons;
    [SerializeField] private List<Quiz> _currentQuizList;
    [SerializeField] private Quiz _currentQuiz;
    [SerializeField] private UnityEvent _onNewQuestionSelected;
    [SerializeField] private UnityEvent _onQuestionExhausted;
    [SerializeField] private UnityEvent<Quiz> _onCorrectAnswerClicked;
    [SerializeField] private UnityEvent _onWrongAnswerClicked;
    [SerializeField] private UnityEvent<Quiz> _onLifeExhausted;

    public void StartQuiz(List<Quiz> quizzes)
    {
        _currentQuizList = quizzes;
        ResetCondition();
    }
    public void UpdateQuiz()
    {
        var pos = Random.Range(0, _currentQuizList.Count);
        _currentQuiz = _currentQuizList[pos];
        _question.text = _currentQuiz.Question;
        var count = 0;
        for (count = 0; count < _currentQuiz.Selection.Length; count++)
            _answerButtons[count].Init(_currentQuiz.Selection[count]);
        for (var i = count; i < _answerButtons.Length; i++) _answerButtons[i].gameObject.SetActive(false);
        _currentQuizList.Remove(_currentQuiz);
        
        _onNewQuestionSelected.Invoke();//새로운 문제 할당시 발동
    }

    public void Correct()
    {
        Debug.Log("Correct");
        _onCorrectAnswerClicked.Invoke(_currentQuiz);
        //ResetCondition();
    }

    public void Wrong()
    {
        Debug.Log("Wrong");
        _currentLifeCount--;
        _onWrongAnswerClicked.Invoke();
        if (_currentLifeCount <= 0)
            _onLifeExhausted.Invoke(_currentQuiz);
    }
    public void ResetCondition()
    {
        _currentLifeCount = _maxLifeCount;
        if (_currentQuizList.Count <= 0)
        {
            Debug.Log("Out of quiz.");
            _onQuestionExhausted.Invoke();//퀴즈 전부 소진시 발동
            return;
        }
        UpdateQuiz();
    }

    public void OnAnswerButtonClicked(int answerPos)
    {
        if (answerPos == _currentQuiz.Answer)
        {
            Correct();
            return;
        }
        Wrong();
    }
    private void OnValidate()
    {
        try
        {
            _answerButtons = GetComponentsInChildren<AnswerButton>();
            for (var i = 1; i <= 5; i++) _answerButtons[i - 1].Position = i;
        }
        catch (Exception e)
        {
            Debug.LogWarning("Answer button import fail.");
        }
    }
}