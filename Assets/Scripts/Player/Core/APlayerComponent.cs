using UnityEngine;

public abstract class APlayerComponent : MonoBehaviour, IPlayerComponent
{
    protected Player p_parentPlayer;
    public bool IsEnabled { get; private set; }

    #region playerInterface
    public virtual void Manage()
    {
    }

    public virtual void FixedManage()
    {
    }

    public virtual void InitModule()
    {
        p_parentPlayer = GetComponentInParent<Player>();
        IsEnabled = false;
    }

    public virtual void Enable()
    {
    }

    public virtual void Disable()
    {
    }

    public virtual void Cleanup()
    {
    }
    #endregion

    protected T GetPlayerComponent<T>() where T : IPlayerComponent
    {
        return p_parentPlayer.GetPlayerComponent<T>();
    }
}