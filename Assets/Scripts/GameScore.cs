using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    
    void Update()
    {
        scoreText.text = GameManager.Instance.score.ToString("D4");
    }
}
