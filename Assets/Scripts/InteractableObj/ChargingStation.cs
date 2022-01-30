using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingStation : AInteractionController
{
    private bool m_isUsed;
    private Player m_playerRef;
    public Transform targetPoint_faceLeft, targetPoint_faceRight;
    public float posConformSpeed = 8f;
    private Transform m_targetPoint;

    public Player PlayerRef => m_playerRef;
    public bool IsUsed => m_isUsed;
    
    
    public override void useObj(Player player)
    {
        base.useObj(player);
        if (m_playerRef != null && player != m_playerRef)
            return;
       
        if (m_isUsed)
        {
            m_playerRef = null;
            m_isUsed = false;
            player.GetPlayerComponent<PlayerMovementController>().Enable();
            player.GetPlayerComponent<PlayerAnimationController>().IsCharging = false;
        }
        else
        {
            m_playerRef = player;
            var playerCtrl = player.GetPlayerComponent<PlayerMovementController>();
            m_targetPoint = playerCtrl.FacingRight ? targetPoint_faceRight : targetPoint_faceLeft; 
            m_isUsed = true;
            playerCtrl.Disable();
            player.GetPlayerComponent<PlayerAnimationController>().IsCharging = true;
        }
        
    }

    private void Update()
    {
        if (m_playerRef)
        {
            
            
            var targetPos = m_playerRef.transform.position;
            targetPos.x = m_targetPoint.position.x;
            targetPos.y = m_targetPoint.position.y;
            m_playerRef.transform.position = Vector3.Lerp(
                m_playerRef.transform.position,
                targetPos,
                posConformSpeed * Time.deltaTime);
        }
    }
}
