using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndPanel : UIWindow
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void Open()
    {
        _scoreText.text = $"당신의 점수는 <color=red>{GameManager.Score}</color>점 입니다.";
        base.Open();
    }
}
