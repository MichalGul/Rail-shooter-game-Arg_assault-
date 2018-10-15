using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    
    private int currentSceneIndex;
    private int nextSceneIndex;

    // Update is called once per frame
    void Update()
    {
        Invoke("LoadNextScene", 3);

    }

    private void LoadNextScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 1) { return; }
        SceneManager.LoadScene(GetNextSceneIndex());

    }

    private int GetNextSceneIndex()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = currentSceneIndex + 1;
        return nextSceneIndex;
    }
}
