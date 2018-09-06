using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadLevel : MonoBehaviour {

    
    public AudioSource startUpSound;
    [SerializeField]
    public AudioClip startUpClip;

    private int currentSceneIndex;
    private int nextSceneIndex;

    // Use this for initialization

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start ()
    {

        startUpSound = GetComponent<AudioSource>();
        startUpSound.PlayOneShot(startUpClip);
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Invoke("LoadNextScene", 5);

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
