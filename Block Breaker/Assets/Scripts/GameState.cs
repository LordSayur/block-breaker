using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    [SerializeField][Range(0.1f,10)] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlockDestroyed = 5;
    [SerializeField]private TextMeshProUGUI scoreText;


    private int currentScore = 0;

    private void Start() {
        scoreText.text = currentScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
}
