using UnityEngine;
using UnityEngine.UI;

public class ResettableTimer : MonoBehaviour
{
    public Text timerText;
    private float startTime;


    void Start()
    {
        if (PlayerPrefs.HasKey("StartTime"))
        {
            startTime = PlayerPrefs.GetFloat("StartTime");
        }
        else
        {
            // 保存されたstartTimeがない場合は新しく設定して保存する
            startTime = Time.time;
            PlayerPrefs.SetFloat("StartTime", startTime);
            PlayerPrefs.Save();
        }
        // startTime = Time.time;
    }

    void Update()
    {
        float t = Time.time - startTime;
        string seconds = t.ToString("f2");
        timerText.text = seconds;
    }
}

