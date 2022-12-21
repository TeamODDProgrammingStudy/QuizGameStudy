using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "QuizList",menuName = "ScriptableObject/QuizList")]
    public class QuizList : ScriptableObject
    {
        public List<Quiz> _quizzes = new List<Quiz>();

        public List<Quiz> GetRandomQuizzesByLength(int length)
        {
            //요청된 퀴즈 크기가 현재 소유한 퀴즈 크기보다 크면 그냥 퀴즈 반환
            if (length > _quizzes.Count) return _quizzes;
            //아니면 랜덤한 퀴즈 리스트 생성
            List<Quiz> result = new List<Quiz>();
            while (result.Count < length)
            {
                var quiz = _quizzes[Random.Range(0, _quizzes.Count)];
                if (result.Contains(quiz)) continue;
                result.Add(quiz);
            }
            return result;
        }
    }
}