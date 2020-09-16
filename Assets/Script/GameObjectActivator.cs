using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectActivator : MonoBehaviour
{
    public GameObject target;
    public string buttonName;
    public bool activeOnStart = true;

    private void Start()
    {
        target.SetActive(activeOnStart);
    }

    private void Update()
    {
        if (Input.GetButtonDown(buttonName))
            ToggleGameObjectActive();
    }

    public void ToggleGameObjectActive()
    {
        target.SetActive(!target.activeSelf);
    }

    public void Activate()
    {
        target.SetActive(true);
    }

    public void Deactivate()
    {
        target.SetActive(false);
    }
}
