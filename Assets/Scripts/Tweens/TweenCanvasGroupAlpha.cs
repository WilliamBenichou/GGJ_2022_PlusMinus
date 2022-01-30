using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WBEngine.UI
{
    public class TweenCanvasGroupAlpha : Tweener<float>
    {
        private CanvasGroup target;

        private void Reset()
        {
            startValue = 0;
            endValue = 1;
            playOnAwake = false;
            duration = 0.20f;
            playMode = EPlayModes.Once;
        }


        public override void ResetTarget()
        {
            target = GetComponent<CanvasGroup>();
        }

        protected override void SetValue(float val)
        {
            if(target)
                target.alpha = Mathf.Lerp(startValue, endValue, val);
        }
    }
}

