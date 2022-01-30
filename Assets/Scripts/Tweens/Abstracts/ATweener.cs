using System;
using UnityEngine;
using UnityEngine.Events;


public abstract class ATweener : MonoBehaviour
{
    protected virtual void Awake()
    {
        ResetTarget();
    }

    public abstract void PlayForward();
    public abstract void PlayForward(onFinished onFinished, bool useDelay = true);
    public abstract void PlayReverse(onFinished onFinished = null);
    public abstract void StopTweenIfActive();
    public abstract void Update();
    public abstract void ResetToBeginning();
    public abstract void ResetToEnd();

    public EPlayModes playMode = EPlayModes.Once;
    public UnityEvent OnTweenFinished, OnTweenStarted;

    public ATweener[] onStartTweens, onFinishTweens;

    public bool IsPlaying { get; protected set; }

    public enum EPlayModes
    {
        Once,
        Loop,
        PingPong
    }

    public abstract void ResetTarget();
}