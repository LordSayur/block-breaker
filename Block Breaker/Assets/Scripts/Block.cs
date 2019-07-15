using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Level level;
    private GameState gameState;
    [SerializeField] private AudioClip destroyClip;
    
    private void Start() {
        gameState = FindObjectOfType<GameState>();
        level = FindObjectOfType<Level>();
        level.RegisterBreakable();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(destroyClip, Camera.main.transform.position);
        level.DestroyedBreakable();
        gameState.AddToScore();
        Destroy(gameObject);
    }
}
