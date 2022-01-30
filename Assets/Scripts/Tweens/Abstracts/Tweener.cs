using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif

public delegate void onFinished(bool wasReversed);

public abstract class Tweener<T> : ATweener
{
    public T startValue, endValue;
    public float startDelay = 0f;
    public float duration = 1f;
    public AnimationCurve curve = AnimationCurve.Linear(0, 0, 1, 1);
    public bool playOnAwake = true;
    private bool _isReversed = false;
    private float _currentTime;
    private onFinished _onFinished = null;
    private bool _delayStart;
    private float _currentDelay;
    public bool useUnscaledTime;

    protected override void Awake()
    {
        base.Awake();

        if (playOnAwake)
        {
            PlayForward();
        }
    }

    protected virtual void OnEnable()
    {
        if (playOnAwake)
        {
            PlayForward();
        }
    }


    public override void PlayForward()
    {
        PlayForward(null);
    }

    public override void PlayForward(onFinished onFinished, bool useDelay = true)
    {
        if (onFinishTweens != null)
        {
            foreach (var tween in onFinishTweens)
                tween.StopTweenIfActive();
        }

        if (onStartTweens != null)
        {
            foreach (var tween in onStartTweens)
                tween.PlayForward();
        }


        _onFinished = onFinished;
        if (useDelay && startDelay > 0)
        {
            SetValue(curve.Evaluate(0));
            _delayStart = true;

            _currentDelay = startDelay;
        }
        else
        {
            _delayStart = false;
            _currentTime = 0;
            _isReversed = false;
            IsPlaying = true;
            SetValue(curve.Evaluate(0));
            OnTweenStarted?.Invoke();
        }
    }

    private IEnumerator PlayDelayed(onFinished onFinished)
    {
        yield return new WaitForSeconds(startDelay);
        PlayForward(onFinished, false);
    }

    public override void PlayReverse(onFinished onFinished = null)
    {
        _onFinished = onFinished;
        _currentTime = duration;
        _isReversed = true;
        IsPlaying = true;
        SetValue(curve.Evaluate(1));
        OnTweenStarted?.Invoke();
    }

    public override void StopTweenIfActive()
    {
        IsPlaying = false;
        foreach (var tween in onStartTweens)
        {
            tween.StopTweenIfActive();
            tween.ResetToBeginning();
        }
    }


    public override void ResetToBeginning()
    {
        SetValue(0f);
    }

    public override void ResetToEnd()
    {
        SetValue(1f);
    }

    public override void Update()
    {
        if (_delayStart)
        {
            _currentDelay -= (useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime);
            if (_currentDelay <= 0)
                PlayForward(_onFinished, false);
        }

        if (IsPlaying)
        {
            if (_isReversed)
            {
                _currentTime -= (useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime);
                if (_currentTime <= 0)
                {
                    SetValue(curve.Evaluate(0));

                    switch (playMode)
                    {
                        case EPlayModes.Once:
                            Stop();
                            break;
                        case EPlayModes.PingPong:
                            _isReversed = false;
                            _currentTime = 0;
                            break;
                        case EPlayModes.Loop:
                            _currentTime = duration;
                            break;
                    }
                }
                else
                {
                    SetValue(curve.Evaluate(_currentTime / duration));
                }
            }
            else
            {
                _currentTime += (useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime);
                if (_currentTime >= duration)
                {
                    SetValue(curve.Evaluate(1));

                    switch (playMode)
                    {
                        case EPlayModes.Once:
                            Stop();
                            break;
                        case EPlayModes.PingPong:
                            _isReversed = true;
                            _currentTime = duration;
                            break;
                        case EPlayModes.Loop:
                            _currentTime = 0;
                            break;
                    }
                }
                else
                {
                    SetValue(curve.Evaluate(_currentTime / duration));
                }
            }
        }
    }

    private void Stop()
    {
        IsPlaying = false;
        _onFinished?.Invoke(true);
        OnTweenFinished?.Invoke();
        if (onFinishTweens != null)
        {
            foreach (var tween in onFinishTweens)
                tween?.PlayForward();
        }
    }

    protected abstract void SetValue(float val);
}