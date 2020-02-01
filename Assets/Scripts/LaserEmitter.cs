using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEmitter : ReactiveObject
{
    public bool isOn = true;

    LineRenderer lr;

    LaserSensor lastSensorHit;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    public override void Activate()
    {
        base.Activate();

        isOn = true;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        isOn = false;
    }

    private void Update()
    {
        if (isOn) ShootLaser();
    }

    void ShootLaser()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(this.transform.position, this.transform.right);

        // If it hits something...
        if (hitInfo.collider != null)
        {
            GameObject hitObj = hitInfo.collider.gameObject;

            lr.SetPosition(0, this.transform.position);
            lr.SetPosition(1, hitInfo.point);

            if(hitObj.tag == "Player") { WorldManager.worldManager.Kill(); return; }

            if (hitObj.GetComponent<LaserSensor>() != null)
            {
                if (lastSensorHit != null && lastSensorHit != (hitObj.GetComponent<LaserSensor>()))
                {
                    lastSensorHit.Deactivate();
                    lastSensorHit = null;
                }

                lastSensorHit = hitObj.GetComponent<LaserSensor>();
                lastSensorHit.Activate();
            }
            else if(lastSensorHit != null)
            {
                lastSensorHit.Deactivate();
                lastSensorHit = null;
            }
        }
        else
        {
            lr.SetPosition(0, this.transform.position);
            lr.SetPosition(1, this.transform.position);

            if (lastSensorHit != null)
            {
                lastSensorHit.Deactivate();
                lastSensorHit = null;
            }
        }
    }
}
