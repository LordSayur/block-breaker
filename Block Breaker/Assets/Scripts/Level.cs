using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // state variables
    private int breakable;

    // cached references
    private SceneLoader sceneLoader;

    private void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void RegisterBreakable(){
        breakable++;
    }

    public void DestroyedBreakable(){
        breakable--;

        if (breakable <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
