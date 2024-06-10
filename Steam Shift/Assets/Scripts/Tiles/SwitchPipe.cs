using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPipe : MonoBehaviour
{
    public List<GameObject> on = new List<GameObject> ();
    public List<GameObject> off = new List<GameObject>();
    public GameObject button;
    public bool isOn;

    void Update()
    {
        isOn = button.GetComponent<PressableButton>().activating.Count != 0 || button.GetComponent<PressableLever>().activating.Count != 0;
        if (isOn)
        {
            foreach (GameObject barrier in on)
            {
                barrier.SetActive(true);
            }
            foreach (GameObject barrier in off)
            {
                barrier.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject barrier in on)
            {
                barrier.SetActive(false);
            }
            foreach (GameObject barrier in off)
            {
                barrier.SetActive(true);
            }
        }
    }
}
