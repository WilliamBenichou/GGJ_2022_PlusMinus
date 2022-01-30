using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenPosition : TransformTweener<Vector3>
{
    public bool useLocalPos = true;

    protected override void SetValue(float val)
    {
        if (useLocalPos)
        {
            if (m_isRectTransform)
                m_rectTarget.anchoredPosition = Vector3.Lerp(startValue, endValue, val);
            else
                transform.localPosition = Vector3.Lerp(startValue, endValue, val);
        }

        else
            transform.position = Vector3.Lerp(startValue, endValue, val);
    }
}