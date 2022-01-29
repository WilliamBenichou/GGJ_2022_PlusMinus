using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMovementController : APlayerComponent
{
    [Header("References")]
    [SerializeField] private Rigidbody2D m_rigidbody2D;
    
    [Header("Parameters")]
    [SerializeField] private float m_jumpForce = 20;
    [SerializeField] private float m_playerSpeed = 3;

    [Tooltip("Time to conform to input in seconds")] [SerializeField]
    private float m_movementConformTime = 0.6f;

    [SerializeField] private float groundDetectionRadius = 0.1f;
    [SerializeField] private LayerMask groundDetectionMask = LayerMask.NameToLayer("ground");
    
    public bool IsGrounded { get; set; }

#if DEVELOPMENT_BUILD || UNITY_EDITOR
    [Header("Debugging")]
    [SerializeField] private bool m_debugMode = false;
    [SerializeField] private bool m_debugGroundDetection = true;
    [SerializeField] private Color m_groundDetectionDebugColor = new Color(1f, 0.32f, 0.27f, 0.6f);
#endif

    private GameControls m_actions;
    private float m_movementInput = 0;
    private float m_currentInput = 0;

    #region Input

    public override void InitModule()
    {
        base.InitModule();
        m_actions = PlayerManager.GetPlayerActions(p_parentPlayer.PlayerIndex);
    }

    public override void Enable()
    {
        base.Enable();
        m_actions.Controls.Jump.performed += OnJump;
    }

    public override void Disable()
    {
        m_actions.Controls.Jump.performed -= OnJump;
        base.Disable();
    }

    public override void Manage()
    {
        base.Manage();
        m_movementInput = m_actions.Controls.Move.ReadValue<float>();
    }

    #endregion

    #region Movement

    public override void FixedManage()
    {
        base.FixedManage();
        m_currentInput = Mathf.MoveTowards(m_currentInput, m_movementInput, m_movementConformTime * Time.deltaTime);

        Vector2 velocity = m_rigidbody2D.velocity;
        velocity.x = m_currentInput * m_playerSpeed;
        m_rigidbody2D.velocity = velocity;

        IsGrounded = Physics2D.OverlapCircle(transform.position, groundDetectionRadius, groundDetectionMask) != null;
    }
    
    private void OnJump(InputAction.CallbackContext a_obj)
    {
        m_rigidbody2D.AddForce(Vector2.up * m_jumpForce);
    }

    #endregion

#if DEVELOPMENT_BUILD || UNITY_EDITOR
// DEBUG
private void OnDrawGizmos()
{
    if (m_debugMode)
    {
        if (m_debugGroundDetection)
        {
            Gizmos.color = m_groundDetectionDebugColor;
            Gizmos.DrawSphere(transform.position, groundDetectionRadius);
        }
    }
}
#endif
}