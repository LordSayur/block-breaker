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
    
    void Start()
    {
        paddlePosMax = screenWidthInUnits;
        paddlePosMin += paddleWidth / 2f;
        paddlePosMax -= paddleWidth / 2f;
    }

    void Update()
    {
        float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePositionInUnits, paddlePosMin, paddlePosMax);
        transform.position = paddlePos;
    }
}
