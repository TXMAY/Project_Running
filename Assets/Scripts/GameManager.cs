using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingleTon<GameManager>
{
    public float globalSpeed = 1.0f;
    public int score = 0;
    public float preScore = 0;
    public bool isGameOver = false;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Game")
        {
            globalSpeed = 1.0f;
            score = 0;
            preScore = 0;
            isGameOver = false;
        }
    }
    void Update()
    {
        if (!isGameOver)
        {
            globalSpeed += Time.deltaTime / 100;
            preScore += Time.deltaTime * 5;
            score = (int)preScore;
        }
        else
        {
            globalSpeed = 0f;
        }
    }
    public void GameOver()
    {
        SceneManager.LoadScene("Result");
    }
}
