using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIWindow : MonoBehaviour
{
    [SerializeField] protected Animator _windowAnimator;
    [SerializeField] private UnityEvent _onWindowOpened;
    [SerializeField] private UnityEvent _onWindowClosed;

    public virtual void Open()
    {
        _windowAnimator.SetTrigger("Open");
        _onWindowOpened.Invoke();
    }

    public virtual void Close()
    {
        _windowAnimator.SetTrigger("Close");
        _onWindowClosed.Invoke();
    }
}
