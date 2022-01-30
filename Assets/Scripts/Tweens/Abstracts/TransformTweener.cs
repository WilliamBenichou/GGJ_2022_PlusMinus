using UnityEngine;

public abstract class TransformTweener<T> : Tweener<T>
{
    protected Transform m_target;
    protected bool m_isRectTransform;
    protected RectTransform m_rectTarget;

    public override void ResetTarget()
    {
        m_target = GetComponent<Transform>();
        m_rectTarget = GetComponent<RectTransform>();
        m_isRectTransform = m_rectTarget != null;
    }
}