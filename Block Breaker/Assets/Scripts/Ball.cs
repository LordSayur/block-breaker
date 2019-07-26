using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] private Paddle paddle;
    [SerializeField] private float xPushMax = 3f;
    [SerializeField] private float xPushMin = -2f;
    [SerializeField] private float yPush = 15f;
    [SerializeField] private AudioClip[] clickClips;
    [SerializeField] private float randomFactor = 1f;

    // state variables
    private Vector2 paddleToBallDistance;
    private bool isStick = true;

    // cached references
    private AudioSource clickSource;
    private Rigidbody2D myRigidBody2D;

    void Start()
    {
        paddleToBallDistance = transform.position - paddle.transform.position;
        clickSource = gameObject.GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

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
        Vector2 VelocityModifier = new Vector2(
                Random.Range(randomFactor * -1, randomFactor),
                Random.Range(randomFactor * -1, randomFactor)
             );
        if (!isStick)
        {
            AudioClip clickAudio = clickClips[UnityEngine.Random.Range(0,clickClips.Length)];
            clickSource.PlayOneShot(clickAudio);
            myRigidBody2D.velocity += VelocityModifier;
        }
    }

    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isStick = !isStick;
            myRigidBody2D.velocity = new Vector2(UnityEngine.Random.Range(xPushMin, xPushMax), yPush);
        }
    }

    private void StickBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallDistance;
    }
}
