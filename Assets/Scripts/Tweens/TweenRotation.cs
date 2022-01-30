using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TweenRotation : TransformTweener<Vector3>
{
    protected override void SetValue(float val)
    {
        if (m_target == null) m_target = GetComponent<Transform>();
        m_target.localRotation = Quaternion.Euler(Vector3.Lerp(startValue, endValue, val));
    }
}