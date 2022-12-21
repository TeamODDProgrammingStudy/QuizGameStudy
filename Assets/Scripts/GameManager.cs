using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Score { get; private set; }
    [SerializeField] private int _gameQuizLength = 3;
    [SerializeField] private QuizList _quizList;
    [SerializeField] private QuizCreator _quizCreator;
    public void IncreaseScore()
    {
        Score++;
    }
    public void ResetData()
    {
        Score = 0;
    }

    public void StartGame()
    {
        _quizCreator.StartQuiz(_quizList.GetRandomQuizzesByLength(_gameQuizLength));
    }
}
