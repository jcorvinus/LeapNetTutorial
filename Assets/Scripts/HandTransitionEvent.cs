using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Leap.Unity;

public class HandTransitionEvent : HandTransitionBehavior
{
    public UnityEvent OnHandReset;
    public UnityEvent OnHandFinish;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void HandReset()
    {
        OnHandReset.Invoke();
    }

    protected override void HandFinish()
    {
        OnHandFinish.Invoke();
    }
}
