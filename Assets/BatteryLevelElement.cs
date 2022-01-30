using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryLevelElement : MonoBehaviour
{
    public ATweener chargingTween, discharchingTween, chargedTween;
    public GameObject visual;
    
    public enum EStates
    {
        Discharged,
        Charging,
        Discharging,
        Charged
    }

    private EStates m_currentState;

    private void Awake()
    {
        m_currentState = EStates.Discharged;
        visual.SetActive(false);
    }

    public void SetState(EStates state)
    {
        if (state == m_currentState)
            return;
        m_currentState = state;
        visual.SetActive(true);
        chargingTween.StopTweenIfActive();
        discharchingTween.StopTweenIfActive();
        chargedTween.StopTweenIfActive();
        switch (state)
        {
            case EStates.Discharged:
                visual.SetActive(false);
                break;
            case EStates.Charging:
                chargingTween.PlayForward();
                break;
            case EStates.Discharging:
                discharchingTween.PlayForward();
                break;
            case EStates.Charged:
                chargedTween.PlayForward();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
}
