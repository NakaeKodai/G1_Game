using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;  // Textオブジェクトへの参照

    private int score;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            // PlayerPrefsからscoreをロード
            score = PlayerPrefs.GetInt("Score", 0);
            UpdateScoreText();  // 初期表示更新
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseScore()
    {
        // scoreを増やして保存
        score++;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();

        UpdateScoreText();  // 表示更新
    }

    private void UpdateScoreText()
    {
        // Textオブジェクトにスコアを表示
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void ResetScore()
    {
        // スコアを初期化して保存
        score = 0;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();

        UpdateScoreText();  // 表示更新
    }

    public void ClearScene()
    {
        // 新しいシーンに遷移する前に、ScoreManagerを破棄
        Destroy(gameObject);

        // 次のシーンに遷移
        SceneManager.LoadScene("Clear");
    }

    public void FailureScene()
    {
        // 新しいシーンに遷移する前に、ScoreManagerを破棄
        Destroy(gameObject);

        // 次のシーンに遷移
        SceneManager.LoadScene("Failure");
    }
    // public static ScoreManager instance;
    // public Text scoreText;  // Textオブジェクトへの参照

    // private int score = 0;

    // void Start()
    // {
    //     // score = 0;
    // }

    // void Awake()
    // {
    //     if (instance == null)
    //     {
    //         instance = this;

    //         GameObject scoreManagerRoot = new GameObject("ScoreManagerRoot");
    //         transform.parent = scoreManagerRoot.transform;

    //         // シーンが切り替わってもオブジェクトが破棄されないようにする
    //         DontDestroyOnLoad(scoreManagerRoot);

    //         // PlayerPrefsからscoreをロード
    //         score = PlayerPrefs.GetInt("Score", 0);
    //         UpdateScoreText();  // 初期表示更新
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    // public void IncreaseScore()
    // {
    //     // scoreを増やして保存
    //     score++;
    //     PlayerPrefs.SetInt("Score", score);
    //     PlayerPrefs.Save();

    //     UpdateScoreText();  // 表示更新
    // }

    // private void UpdateScoreText()
    // {
    //     // Textオブジェクトにスコアを表示
    //     if (scoreText != null)
    //     {
    //         scoreText.text = "Score: " + score.ToString();
    //     }
    // }
}
