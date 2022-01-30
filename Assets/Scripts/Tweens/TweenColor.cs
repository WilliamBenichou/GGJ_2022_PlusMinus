using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WBEngine
{
    public class TweenColor : GraphicTweener<Color>
    {

        protected override void SetValue(float val)
        {
            _target.color = Color.Lerp(startValue, endValue, Mathf.Clamp01(val));
            base.SetValue(val);
        }
    }
}

