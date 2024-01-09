using UnityEngine;
using UnityEngine.UI;

public class ResettableTimer : MonoBehaviour
{
    public Text timerText;
    private float elapsedTime;

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        timerText.text = FormatTime(elapsedTime);
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        int milliseconds = Mathf.FloorToInt((time - minutes * 60 - seconds) * 1000);
        string formattedTime = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        return formattedTime;
    }

    public void ResetTimer()
    {
        elapsedTime = 0.0f;
        UpdateTimerText();
    }
}

