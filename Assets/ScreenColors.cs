using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ScreenColors : MonoBehaviour
{
    public BatteryScreen redScreen, greenScreen, blueScreen;
    public GameObject[] redLights, greenLights, blueLights;

    public bool targetBlue = true, targetRed = true, targetGreen = false;

    public GameObject toEnableOnWin;
    public GameObject toDisableOnWin;
    
    
    private void Update()
    {
        bool redOn = redScreen.IsFullyCharged;
        bool greenOn = greenScreen.IsFullyCharged;
        bool blueOn = blueScreen.IsFullyCharged;

        foreach (GameObject light in redLights)
        {
            light.SetActive(redOn);
        }
        foreach (GameObject light in greenLights)
        {
            light.SetActive(greenOn);
        }
        foreach (GameObject light in blueLights)
        {
            light.SetActive(blueOn);
        }

        IsOk = redOn == targetRed && greenOn == targetGreen && blueOn == targetBlue;
        toEnableOnWin.SetActive(IsOk);
        toDisableOnWin.SetActive(!IsOk);
    }

    public bool IsOk { get; set; }
}
