using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightComponent : MonoBehaviour
{
    public Action<Collider> OnSightUpdated;

    public string targetTag;
    public float exitSightWait = 5.0f;

    private Collider collider = null;
    private Collider inSight = null;

    private float exitSightTimer = -1.0f;
    private bool waitOutOfSight = false;

    private void Awake()
    {
        collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (waitOutOfSight)
        {
            exitSightTimer -= Time.deltaTime;
            if (exitSightTimer <= 0.0f)
            {
                waitOutOfSight = false;
                inSight = null;
                OnSightUpdated?.Invoke(null);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == targetTag) 
        {
            inSight = other;
            OnSightUpdated?.Invoke(inSight);
            if (waitOutOfSight)
            {
                waitOutOfSight = false;
                exitSightTimer = -1.0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == inSight && !waitOutOfSight)
        {
            StartWaitOutOfSight();
        }
    }

    private void StartWaitOutOfSight()
    {
        waitOutOfSight = true;
        exitSightTimer = exitSightWait;
    }
}
