using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField]
    private Paddle paddle;
    [SerializeField]
    private float xPushMax = 3f;
    [SerializeField]
    private float xPushMin = -2f;
    [SerializeField]
    private float yPush = 15f;
    private AudioSource click;

    // state
    private Vector2 paddleToBallDistance;
    private bool isStick = true;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallDistance = transform.position - paddle.transform.position;
        click = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStick)
        {
            StickBallToPaddle();
            LaunchBall();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isStick)
        {
            click.Play();
        }
    }

    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isStick = !isStick;
            GetComponent<Rigidbody2D>().velocity = new Vector2(UnityEngine.Random.Range(xPushMin, xPushMax), yPush);
        }
    }

    private void StickBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallDistance;
    }
}
