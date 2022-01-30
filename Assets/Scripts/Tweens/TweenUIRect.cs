using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class TweenUIRect : TransformTweener<float>
{
    public enum ETargetProperties
    {
        Width,
        Height
    }

    public ETargetProperties targetProperty;

    protected override void SetValue(float val)
    {

        val = Mathf.Lerp(startValue, endValue, val);

        Vector2 size = m_rectTarget.sizeDelta;
        switch (targetProperty)
        {
            case ETargetProperties.Width:
                size.x = val;
                break;
            case ETargetProperties.Height:
                size.y = val;
                break;
        }
        m_rectTarget.sizeDelta = size;

        
    }
}
