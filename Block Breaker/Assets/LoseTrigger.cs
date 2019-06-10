﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    SceneLoader SceneLoader;

    private void Awake()
    {
        SceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneLoader != null)
        {
            SceneLoader.LoadNextScene("Game Over");
        }
    }
}
