using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WBEngine.UI
{
    public class TweenAlpha : GraphicTweener<float>
    {
        protected override void SetValue(float val)
        {
            if(_target != null)
            {
                Color targetColor = _target.color;
                targetColor.a = Mathf.Lerp(startValue, endValue, Mathf.Clamp01(val));
                _target.color = targetColor;
            }
            base.SetValue(val);
        }


    }
}

