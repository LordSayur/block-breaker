using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    /* #region  variables */
    // config params
    [SerializeField] private AudioClip destroyClip;
    [SerializeField] private GameObject blockSparklesVFX;
    [SerializeField] private int maxHits = 1;
    
    // state variables
    private int timesHit = 0;
    
    // cached references
    private Level level;
    private GameState gameState;
    /* #endregion */

    private void Start()
    {
        gameState = FindObjectOfType<GameState>();
        CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.RegisterBreakable();
        }
    }

    private void DestroyBlock()
    {
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
