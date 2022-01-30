using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractController : APlayerComponent
{
    [SerializeField] private float interactRadius = 1.5f;
    [SerializeField] private LayerMask interactDetectionMask;
    
#if DEVELOPMENT_BUILD || UNITY_EDITOR
    [Header("Debugging")] [SerializeField] private bool i_debugMode = false;
    [SerializeField] private bool debugInteractDetection = true;
    [SerializeField] private Color interactDetectionDebugColor = new Color(1f, 0.32f, 0.27f, 0.6f);
#endif

    private GameControls m_actions;
    private Collider2D lastCollider = null;

    public override void FixedManage()
    {
        base.FixedManage();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactRadius, interactDetectionMask);
        if (colliders.Length > 0)
        {
            float bestDist = 99999.0f;
            Collider2D bestCollider = null;
            foreach (Collider2D obj in colliders)
            {
                float distance = Vector2.Distance(transform.position, obj.transform.position);
                if (distance < bestDist)
                {
                    bestDist = distance;
                    bestCollider = obj;
                }
            }
            //player leaves an object
            if (lastCollider != bestCollider && lastCollider != null)
            {
                lastCollider.gameObject.GetComponent<HighlightObj>().PlayerOOS(p_parentPlayer.PlayerIndex);
            }
            bestCollider.gameObject.GetComponent<HighlightObj>().Reached(p_parentPlayer.PlayerIndex);
            lastCollider = bestCollider;
        }
        else
        {
            if (lastCollider != null)
            {
                lastCollider.gameObject.GetComponent<HighlightObj>().PlayerOOS(p_parentPlayer.PlayerIndex);
                lastCollider = null;
            }
        }
    }

    public override void InitModule()
    {
        base.InitModule();
        m_actions = PlayerManager.GetPlayerActions(p_parentPlayer.PlayerIndex);
    }

    public override void Enable()
    {
        base.Enable();
        m_actions.Controls.Interact.performed += OnInteract;
    }

    public override void Disable()
    {
        m_actions.Controls.Interact.performed -= OnInteract;
        base.Disable();
    }
    
    private void OnInteract(InputAction.CallbackContext obj)
    {
        
        if (lastCollider != null)
        {
            lastCollider.gameObject.GetComponent<InteractionController>().useObj(p_parentPlayer.PlayerIndex);
            //do action
        }
    }
    
#if DEVELOPMENT_BUILD || UNITY_EDITOR
// DEBUG
    private void OnDrawGizmos()
    {
        if (i_debugMode)
        {
            if (debugInteractDetection)
            {
                Gizmos.color = interactDetectionDebugColor;
                Gizmos.DrawSphere(transform.position, interactRadius);
            }
        }
    }
#endif
}
