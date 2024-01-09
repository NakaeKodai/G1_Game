using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Text timerText;
    private float Time;

    void Start()
    {
        if (PlayerPrefs.HasKey("StartTime"))
        {
            Time = PlayerPrefs.GetFloat("StartTime");
        }

        string seconds = Time.ToString("f2");
        timerText.text = seconds;
    }

    void Update()
    {
    }
}
