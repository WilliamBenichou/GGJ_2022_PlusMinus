using UnityEngine;

public class PlayerAnimationController : APlayerComponent
{
    [SerializeField] private Animator m_animator;

    private static readonly int F_KEY_SPEED_X_ABS = Animator.StringToHash("speedX_abs");
    private static readonly int F_KEY_SPEED_Y = Animator.StringToHash("speedY");
    private static readonly int B_KEY_GROUNDED = Animator.StringToHash("isGrounded");

    public Vector2 Speed
    {
        set
        {
            m_animator.SetFloat(F_KEY_SPEED_X_ABS, Mathf.Abs(value.x));
            m_animator.SetFloat(F_KEY_SPEED_Y, value.y);
        }
    }
    
    public bool IsGrounded
    {
        set
        {
            m_animator.SetBool(B_KEY_GROUNDED, value);
        }
    }
}