using UnityEngine.UI;

public abstract class GraphicTweener<T> : Tweener<T>
{
    protected Graphic _target;

    protected override void SetValue(float val)
    {
        _target.SetMaterialDirty();
    }

    public override void ResetTarget()
    {
        _target = GetComponent<Graphic>();
    }
}