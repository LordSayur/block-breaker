using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float screenWidthInUnits = 16f;
    [SerializeField]
    private float paddleWidth = 2f;

    private float paddlePosMin = 0f;
    private float paddlePosMax;
    

    // Start is called before the first frame update
    void Start()
    {
        paddlePosMax = screenWidthInUnits;
        paddlePosMin += paddleWidth / 2f;
        paddlePosMax -= paddleWidth / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePositionInUnits, paddlePosMin, paddlePosMax);
        transform.position = paddlePos;
    }
}
