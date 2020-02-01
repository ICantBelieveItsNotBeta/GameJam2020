using System;
using UnityEngine;

public abstract class ReactiveObject : MonoBehaviour
{
    protected bool _opening;

    public virtual void Activate()
    {
    }

    public virtual void Deactivate()
    {
    }

    public void ToggleState()
    {
        _opening = !_opening;
    }
}