using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LaserEmitter : ReactiveObject
{
    public bool isOn = true;
    public bool invert = false;

    Light2D light2D;

    LaserSensor lastSensorHit;

    private void Start()
    {
        light2D = GetComponentInChildren<Light2D>();
    }

    public override void Activate()
    {
        base.Activate();

        isOn = !invert;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        isOn = invert;
    }

    private void Update()
    {
        if (isOn) ShootLaser();
        else { light2D.transform.localScale = Vector3.zero; }
    }

    void ShootLaser()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(light2D.transform.position, this.transform.right);

        // If it hits something...
        if (hitInfo.collider != null)
        {
            GameObject hitObj = hitInfo.collider.gameObject;

            light2D.transform.localScale = new Vector3(1, hitInfo.distance * 2, 1);

            if (hitObj.tag == "Player") { WorldManager.worldManager.Kill(); return; }

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
            else if (lastSensorHit != null)
            {
                lastSensorHit.Deactivate();
                lastSensorHit = null;
            }
        }
        else
        {
            light2D.transform.localScale = new Vector3(1, 100, 1);

            if (lastSensorHit != null)
            {
                lastSensorHit.Deactivate();
                lastSensorHit = null;
            }
        }
    }
}
