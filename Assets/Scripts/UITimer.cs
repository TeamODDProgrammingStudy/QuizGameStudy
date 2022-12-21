using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class UITimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private UnityEvent _onTimerStartEvent;
    [SerializeField] private UnityEvent _onTimerTickEvent;
    [SerializeField] private UnityEvent _onTimerEndEvent;
    [SerializeField] private float _currentTime = 0;
    [SerializeField] private float _timeTick = 1f;
    private IEnumerator _currentTimer;

    public void StartTimer(float time)
    {
        //Debug.Log(_currentTimer == null);
        StopTimer();
        _currentTime = time;
        _currentTimer = TimerUpdate();
        StartCoroutine(_currentTimer);
    }

    public void StopTimer()
    {
        if (_currentTimer != null) {
            StopCoroutine(_currentTimer);
            _currentTimer = null;
        }
    }
    private IEnumerator TimerUpdate()
    {
        _onTimerStartEvent.Invoke();
        while (--_currentTime > 0)
        {
            _timerText.text = $"{_currentTime}";
            
            _onTimerTickEvent.Invoke();
            yield return new WaitForSecondsRealtime(_timeTick);
        }
        _currentTimer = null;
        _onTimerEndEvent.Invoke();
    }

    private void OnValidate()
    {
        _timerText = GetComponentInChildren<TextMeshProUGUI>();
    }
}