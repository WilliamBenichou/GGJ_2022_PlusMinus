using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TweenNumberText : Tweener<long>
{
    private TextMeshProUGUI _target;

    public override void ResetTarget()
    {
        _target = GetComponent<TextMeshProUGUI>();
    }


    protected override void SetValue(float val)
    {
        if (!_target) _target = GetComponent<TextMeshProUGUI>();
        _target.text = Mathf.RoundToInt(Mathf.Lerp(startValue, endValue, val)).ToString();
    }
}