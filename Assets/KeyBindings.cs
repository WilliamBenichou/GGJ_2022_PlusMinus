using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;

public class KeyBindings : MonoBehaviour
{
    [Serializable]
    public struct Layouts
    {
        public GameObject kbLayout, xboxLayout, psLayout;
    }

    [SerializeField] private Layouts[] playersLayouts;

    private void Awake()
    {
        for (int i = 0; i < PlayerManager.PLAYER_COUNT; i++)
        {
            playersLayouts[i].kbLayout.SetActive(false);
            playersLayouts[i].xboxLayout.SetActive(false);
            playersLayouts[i].psLayout.SetActive(false);

            InputDevice device = PlayerManager.GetPlayerDevice(i);
            if (device is Keyboard)
            {
                playersLayouts[i].kbLayout.SetActive(true);
            }
            else if (device is DualShockGamepad)
            {
                playersLayouts[i].psLayout.SetActive(true);
            }
            else
            {
                playersLayouts[i].xboxLayout.SetActive(true);
            }
        }
    }
}
