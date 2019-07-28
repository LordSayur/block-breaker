using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    // config params
    [SerializeField][Range(0.1f,10)] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlockDestroyed = 5;
    [SerializeField]private TextMeshProUGUI scoreText;
    [SerializeField] private bool isAutoPlayEnabled = false;

    // state variables
    private int currentScore = 0;

    private void Awake() {
        int countGameState = FindObjectsOfType<GameState>().Length;
        if (countGameState > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } 
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

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

    public void ResetScore(){
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled(){
        return isAutoPlayEnabled;
    }
}
