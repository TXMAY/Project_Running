using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingleTon<GameManager>
{
    public float globalSpeed = 2.0f;
    public int score = 0;
    [SerializeField] float preScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    void Update()
    {
        globalSpeed += Time.deltaTime / 100;
        preScore += Time.deltaTime * 5;
        score = (int)preScore;
        if (scoreText != null) scoreText.text = score.ToString("D4");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("Result");
    }
}
