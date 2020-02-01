using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSensor : TriggerBase
{
    

    public void Activate()
    {
        foreach (ReactiveObject r in reactiveObjects) r.Activate();
    }

    public void Deactivate()
    {
        foreach (ReactiveObject r in reactiveObjects) r.Deactivate();
    }
}
