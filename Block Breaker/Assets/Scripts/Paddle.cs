using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // config params
    [SerializeField] private float screenWidthInUnits = 16f;
    [SerializeField] private float paddleWidth = 2f;

    // state variables
    private float paddlePosMin = 0f;
    private float paddlePosMax;

    // cached references
    private GameState gameState;
    private Ball ball;
    
    void Start()
    {
        gameState = FindObjectOfType<GameState>();
        ball = FindObjectOfType<Ball>();

        paddlePosMax = screenWidthInUnits;
        paddlePosMin += paddleWidth / 2f;
        paddlePosMax -= paddleWidth / 2f;
    }

    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), paddlePosMin, paddlePosMax);
        transform.position = paddlePos;
    }

    private float GetXPos(){
        if (gameState.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
