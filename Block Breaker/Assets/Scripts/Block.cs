using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Level level;
    private GameState gameState;
    [SerializeField] private AudioClip destroyClip;
    [SerializeField] private GameObject blockSparklesVFX;
    
    private void Start()
    {
        gameState = FindObjectOfType<GameState>();
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.RegisterBreakable();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        if (gameObject.tag == "Unbreakable")
        {
            return;
        }
        AudioSource.PlayClipAtPoint(destroyClip, Camera.main.transform.position);
        level.DestroyedBreakable();
        gameState.AddToScore();
        TriggerSparklesVFX();
        Destroy(gameObject);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, Quaternion.identity);
        Destroy(sparkles, 1f);
    }
}
