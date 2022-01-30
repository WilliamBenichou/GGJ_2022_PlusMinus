using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMovementController : APlayerComponent
{
    [Header("References")] [SerializeField]
    private Rigidbody2D m_rigidbody2D;

    [SerializeField] private Transform m_model;

    [Header("Parameters")] [SerializeField]
    private float m_jumpForce = 20;

    [SerializeField] private float m_playerSpeed = 3;
    [SerializeField] private float m_wallDetectRaycastLength = 3;
    [SerializeField] private float m_wallDetectRaycastHeight = 0.5f;
    [SerializeField] private LayerMask m_wallDetectRaycastMask;


    [Tooltip("Time to conform to input in seconds")] [SerializeField]
    private float m_movementConformTime = 0.6f;

    [SerializeField] private float m_groundDetectionRadius = 0.1f;
    [SerializeField] private LayerMask m_groundDetectionMask;


#if DEVELOPMENT_BUILD || UNITY_EDITOR
    [Header("Debugging")] [SerializeField] private bool m_debugMode = false;
    [SerializeField] private bool m_debugGroundDetection = true;
    [SerializeField] private Color m_groundDetectionDebugColor = new Color(1f, 0.32f, 0.27f, 0.6f);
    [SerializeField] private bool m_debugWallDetection = true;
    [SerializeField] private Color m_wallDetectionDebugColor = new Color(1f, 0.32f, 0.27f, 0.6f);
#endif

    private GameControls m_actions;
    private float m_movementInput = 0;
    private float m_currentInput = 0;
    private PlayerAnimationController m_animController;

    public bool IsGrounded { get; set; }
    public bool FacingRight { get; private set; }

    #region Input

    public override void InitModule()
    {
        base.InitModule();
        m_rigidbody2D.isKinematic = true;
        FacingRight = true;
        m_actions = PlayerManager.GetPlayerActions(p_parentPlayer.PlayerIndex);
        m_animController = GetPlayerComponent<PlayerAnimationController>();
    }

    public override void Enable()
    {
        base.Enable();
        m_rigidbody2D.isKinematic = false;
        m_actions.Controls.Jump.performed += OnJump;
    }

    public override void Disable()
    {
        m_rigidbody2D.isKinematic = true;
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
        IsGrounded = Physics2D.OverlapCircle(transform.position, m_groundDetectionRadius, m_groundDetectionMask) !=
                     null;

        if (m_currentInput > 0)
        {
            FacingRight = true;
        }
        else if (m_currentInput < 0)
        {
            FacingRight = false;
        }


        if (Physics2D.Raycast(
            (Vector2) transform.position + Vector2.up * m_wallDetectRaycastHeight,
            FacingRight ? Vector2.right : Vector2.left,
            m_wallDetectRaycastLength,
            m_wallDetectRaycastMask)
        )
        {
            m_currentInput = 0;
        }

        Vector2 velocity = m_rigidbody2D.velocity;
        velocity.x = m_currentInput * m_playerSpeed;
        m_rigidbody2D.velocity = velocity;

        m_animController.Speed = new Vector2(m_currentInput, velocity.y);
        m_animController.IsGrounded = IsGrounded;

        Vector3 scale = m_model.localScale;
        scale.x = FacingRight ? 1 : -1;
        m_model.localScale = scale;
    }


    private void OnJump(InputAction.CallbackContext a_obj)
    {
        if (!IsGrounded)
        {
            return;
        }

        m_rigidbody2D.AddForce(Vector2.up * m_jumpForce);
        IsGrounded = false;
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
                Gizmos.DrawSphere(transform.position, m_groundDetectionRadius);
            }

            if (m_debugWallDetection)
            {
                Gizmos.color = m_wallDetectionDebugColor;
                Gizmos.DrawRay(
                    transform.position + Vector3.up * m_wallDetectRaycastHeight -
                    Vector3.right * m_wallDetectRaycastLength, Vector3.right * m_wallDetectRaycastLength * 2);
            }
        }
    }
#endif
}