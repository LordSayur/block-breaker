using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Level level;
    [SerializeField] private AudioClip destroyClip;
    
    private void Start() {
        level = FindObjectOfType<Level>();
        level.RegisterBreakable();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(destroyClip, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
