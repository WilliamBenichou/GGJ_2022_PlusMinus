using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TweenScale : TransformTweener<Vector3>
{
    protected override void SetValue(float val)
    {
        if (m_target != null)
        {
            m_target.transform.localScale = Vector3.LerpUnclamped(startValue, endValue, val);
        }
    }
}