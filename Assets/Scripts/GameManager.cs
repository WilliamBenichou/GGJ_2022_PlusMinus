using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public Player[] players;
    public Light2D globalLight;
    
    public CinemachineVirtualCamera vCam1_main, vCam2_dark;

    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
}
