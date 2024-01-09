using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 60.0f; // 初期の制限時間（秒）
    [HideInInspector] public float currentTime; // 現在の残り時間
    public Text timerText; // タイマー表示用のテキスト
    public Color warningColor = Color.red; // 残り時間が少ないときの文字色
    private bool hasTimeRunOut = false; // Debug.Logが一回だけ出力されるようにするためのフラグ

    void Start()
    {
        currentTime = totalTime;
        UpdateTimerText();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime; // 経過時間を減算
            UpdateTimerText();

            // 残り3秒になったら文字の色を赤に変更
            if (currentTime <= 3.0f)
            {
                timerText.color = warningColor;
            }
        }
        else if (!hasTimeRunOut)
        {
            // 制限時間が終了したときの処理
            Debug.Log("Time's up!");
            hasTimeRunOut = true; // Debug.Logが一回だけ出力されるようにフラグを設定
        }
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Max(0, Mathf.FloorToInt(currentTime)).ToString();
    }

    // タイマーを指定秒数だけ増加させるメソッド
    public void AddTime(float seconds)
    {
        currentTime += seconds;
        UpdateTimerText();
    }
}
