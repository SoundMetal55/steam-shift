using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool isOn;
    public float speed;
    public GameObject button;
    public GameObject platform;
    public GameObject pointOne;
    public GameObject pointTwo;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isOn = button.GetComponent<PressableButton>().activating.Count != 0 || button.GetComponent<PressableLever>().activating.Count != 0 || button.GetComponent<PressableAutomatic>().isOn;
        if (isOn)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, pointTwo.transform.position, speed * Time.deltaTime);
        }
        else
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, pointOne.transform.position, speed * Time.deltaTime);
        }

        //if (button.GetComponent<Button>().steamColliding &&  )
    }
}

