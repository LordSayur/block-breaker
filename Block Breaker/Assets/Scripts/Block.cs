using System;
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
    [SerializeField] private Sprite[] blockState;
    
    // state variables
    private int timesHit = 0;
    
    // cached references
    private Level level;
    private GameState gameState;
    private SpriteRenderer blockSprite;
    /* #endregion */

    private void Start()
    {
        gameState = FindObjectOfType<GameState>();
        blockSprite = GetComponent<SpriteRenderer>();
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
        else
        {
            LoadNextSprite();
        }
    }

    private void LoadNextSprite()
    {
        int spriteIndex = timesHit - 1;
        blockSprite.sprite = blockState[spriteIndex];
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
