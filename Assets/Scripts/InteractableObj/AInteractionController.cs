using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AInteractionController : MonoBehaviour
{
    public virtual void useObj(Player player)
    {
    }
    public virtual void startUseObj(Player player)
    {
    }
    public virtual void cancelUseObj(Player player)
    {
    }
    
}
