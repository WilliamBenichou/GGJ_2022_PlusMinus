using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private IPlayerComponent[] m_playerComponents = {};
    [SerializeField] public int PlayerIndex { get; private set; }

    private void Awake()
    {
        foreach (var playerComponent in m_playerComponents)
        {
            playerComponent.InitModule();
        }
    }

    private void OnEnable()
    {
        foreach (var playerComponent in m_playerComponents)
        {
            playerComponent.Enable();
        }
    }

    private void OnDisable()
    {
        foreach (var playerComponent in m_playerComponents)
        {
            playerComponent.Disable();
        }
    }

    private void OnDestroy()
    {
        foreach (var playerComponent in m_playerComponents)
        {
            playerComponent.Cleanup();
        }
    }

    public T GetPlayerComponent<T>() where T : IPlayerComponent
    {
        foreach (IPlayerComponent playerComponent in m_playerComponents)
        {
            if (playerComponent is T) return (T) playerComponent;
        }

        throw new KeyNotFoundException("Couldn't find the module of the requested type, has it been added?");
    }
}
