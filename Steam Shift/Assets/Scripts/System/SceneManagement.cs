using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject engineer;
    public GameObject steam;

    // Start is called before the first frame update
    void Start()
    {
        engineer = GameObject.Find("Engineer");
        steam = GameObject.Find("Steam");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Restart();
        }
        CheckWin();
    }

    void CheckWin()
    {
        Debug.Log(engineer.GetComponent<Engineer>().isAtGoal.ToString() + "en");
        Debug.Log(steam.GetComponent<Steam>().isAtGoal.ToString() + "st");
        if (engineer.GetComponent<Engineer>().isAtGoal == true && steam.GetComponent<Steam>().isAtGoal == true)
        {
            GoToNextLevel();
        }
    }

    void GoToNextLevel()
    {
        Debug.Log("win");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
