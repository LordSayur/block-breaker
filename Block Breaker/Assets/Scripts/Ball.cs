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
    [SerializeField]
    private AudioClip[] clickClips;

    // state
    private Vector2 paddleToBallDistance;
    private bool isStick = true;

    // cached component references
    private AudioSource clickSource;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallDistance = transform.position - paddle.transform.position;
        clickSource = gameObject.GetComponent<AudioSource>();
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
            AudioClip clickAudio = clickClips[UnityEngine.Random.Range(0,clickClips.Length)];
            clickSource.PlayOneShot(clickAudio);
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
