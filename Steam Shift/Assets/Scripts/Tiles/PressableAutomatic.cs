using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableAutomatic : MonoBehaviour
{
    public bool isAutomatic;

    public int seconds;
    public bool isOn;

    void Start()
    {
        if (isAutomatic)
        {
            InvokeRepeating("Activate", 0, seconds);
        }
    }

    private void Activate()
    {
        isOn = !isOn;
    }
}
