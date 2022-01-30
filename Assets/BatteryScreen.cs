using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryScreen : MonoBehaviour
{
    public BatteryLevelElement[] widgets;
    public GameObject positiveSideWidget, positiveSideWidgetInverted;
    public GameObject negativeSideWidget, negativeSideWidgetInverted;

    public float requiredChargeLevel = 100f;
    public float chargeSpeed = 6f;
    public float startChargeLevel = 0f;

    public ChargingStation positiveChargingStation;
    public ChargingStation negativeChargingStation;

    private float m_currChargeLevel;
    private bool m_isFullyCharged;

    public bool IsCharging { get; private set; }

    public bool IsActive { get; private set; }
    public bool IsUIDirty { get; private set; }

    private void Awake()
    {
        m_currChargeLevel = startChargeLevel;
        IsUIDirty = true;
    }


    private void Start()
    {
        foreach (BatteryLevelElement widget in widgets)
        {
            widget.SetState(BatteryLevelElement.EStates.Discharged);
        }

        positiveChargingStation.SetRole(true);
        negativeChargingStation.SetRole(false);
    }

    private void Update()
    {
        float prevChargeLevel = m_currChargeLevel;
        IsActive = positiveChargingStation.IsUsed && negativeChargingStation.IsUsed;
        if (IsActive)
        {
            IsCharging = positiveChargingStation.PlayerRef.PlayerIndex == 0; //player are in given order
            if (IsCharging && m_currChargeLevel < 100)
            {
                m_currChargeLevel += chargeSpeed * Time.deltaTime;
                if (m_currChargeLevel > 100)
                {
                    m_currChargeLevel = 100;
                }
            }
            else if (!IsCharging && m_currChargeLevel > 0)
            {
                m_currChargeLevel -= chargeSpeed * Time.deltaTime;
                if (m_currChargeLevel < 0)
                {
                    m_currChargeLevel = 0;
                }
            }

            if (Math.Abs(prevChargeLevel - m_currChargeLevel) > 0.001f)
                IsUIDirty = true;
        }

        if (IsUIDirty)
            RefreshUI();
    }

    private void RefreshUI()
    {
        float chargePerLevel = requiredChargeLevel / widgets.Length;
        int currChargedWidgets = Mathf.FloorToInt(m_currChargeLevel / chargePerLevel);
        for (int i = 0; i < currChargedWidgets; i++)
        {
            widgets[i].SetState(BatteryLevelElement.EStates.Charged);
        }


        if (IsActive)
        {
            if (IsCharging && currChargedWidgets < widgets.Length)
            {
                widgets[currChargedWidgets].SetState(BatteryLevelElement.EStates.Charging);
            }
            else if (!IsCharging)
            {
                if (m_currChargeLevel > 0)
                {
                    widgets[currChargedWidgets].SetState(BatteryLevelElement.EStates.Discharging);
                }
                else
                {
                    widgets[currChargedWidgets].SetState(BatteryLevelElement.EStates.Discharged);
                }
            }

            for (int i = currChargedWidgets + 1; i < widgets.Length; i++)
            {
                widgets[i].SetState(BatteryLevelElement.EStates.Discharged);
            }
        }

        positiveSideWidget.SetActive(positiveChargingStation.IsUsed &&
                                     positiveChargingStation.PlayerRef.PlayerIndex == 0);
        positiveSideWidgetInverted.SetActive(positiveChargingStation.IsUsed &&
                                             positiveChargingStation.PlayerRef.PlayerIndex == 1);
        negativeSideWidget.SetActive(negativeChargingStation.IsUsed &&
                                     negativeChargingStation.PlayerRef.PlayerIndex == 1);
        negativeSideWidgetInverted.SetActive(negativeChargingStation.IsUsed &&
                                             negativeChargingStation.PlayerRef.PlayerIndex == 0);
    }
}