using System;
using UnityEngine;

public abstract class ReactiveObject : MonoBehaviour
{
    private bool _active = false;
    
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
        _active = !_active;
    }
}