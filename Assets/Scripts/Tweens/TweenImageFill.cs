using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweenImageFill : Tweener<float>
{
    private Image m_target;

    protected override void Awake()
    {
        base.Awake();
        ResetTarget();
    }

    public override void ResetTarget()
    {
        m_target = GetComponent<Image>();
    }

    protected override void SetValue(float val)
    {
        if (m_target != null)
        {
            m_target.fillAmount = Mathf.Clamp01(Mathf.Lerp(startValue, endValue, val));
        }
    }
}