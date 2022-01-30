using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ATweener), true)]
public class TweenerEditor : Editor
{
    public bool _isPlaying;
    private ATweener _target;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (!_target) _target = (ATweener)target;

        GUILayout.Space(10);
        if (_isPlaying)
        {
            if (GUILayout.Button("Stop"))
            {
                StopBtnClicked();
            }
        }
        else
        {
            if (GUILayout.Button("Play"))
            {
                PlayBtnClicked();

            }

        }

        if (GUILayout.Button("Play all attached teens"))
        {

            var otherTargets = (TweenerEditor[])Resources.FindObjectsOfTypeAll(typeof(TweenerEditor));
            foreach (var target in otherTargets)
            {
                if (!target._isPlaying)
                    target.PlayBtnClicked();
            }
        }
        if (GUILayout.Button("Stop all attached teens"))
        {

            var otherTargets = (TweenerEditor[])Resources.FindObjectsOfTypeAll(typeof(TweenerEditor));
            foreach (var target in otherTargets)
            {
                target.StopBtnClicked();
            }
        }

    }

    private void StopBtnClicked()
    {
        if (!_target) _target = (ATweener)target;
        _target.StopTweenIfActive();
        _target.ResetToBeginning();
        EditorApplication.update -= _target.Update;
        _isPlaying = false;
    }

    private void PlayBtnClicked()
    {
        if (!_target) _target = (ATweener)target;
        _target.ResetTarget();
        _target.PlayForward(
                                o =>
                                {
                                    _isPlaying = false;
                                    EditorApplication.update -= _target.Update;
                                }
                            );
        EditorApplication.update += _target.Update;
    }
}