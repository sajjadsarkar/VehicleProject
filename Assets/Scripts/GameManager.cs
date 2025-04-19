using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CarController CarController;
    private bool isOn = false;
    private bool isOnLight = false;
    public Light[] lights;

    private void Start()
    {
        SetLightsEnabled(false);
    }
    public void StartStop()
    {
        if (isOn)
        {
            CarController.enabled = false;
            isOn = false;
        }
        else
        {
            CarController.enabled = true;
            isOn = true;
        }
    }


    public void LightOnOff()
    {
        if (isOnLight)
        {
            SetLightsEnabled(false); // Turn off all lights.
            isOnLight = false;
        }
        else
        {
            SetLightsEnabled(true); // Turn on all lights.
            isOnLight = true;
        }
    }

    private void SetLightsEnabled(bool isEnabled)
    {
        foreach (Light light in lights)
        {
            light.enabled = isEnabled;
        }
    }
}
