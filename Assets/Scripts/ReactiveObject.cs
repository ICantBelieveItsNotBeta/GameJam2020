using System;
using UnityEngine;

public abstract class ReactiveObject : MonoBehaviour
{
    protected bool _opening;
    
    public virtual void Activate()
    {
        throw new NotImplementedException("You fucking tool");
    }

    public virtual void Deactivate()
    {
        throw new NotImplementedException("You fucking tool");
    }

    public void ToggleState()
    {
        _opening = !_opening;
    }
}