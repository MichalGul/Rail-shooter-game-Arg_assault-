using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public AudioSource startUpSound;
    [SerializeField]
    public AudioClip startUpClip;

    // Use this for initialization

    void Awake()
    {
        var MusicPlayers = FindObjectsOfType<MusicPlayer>();
        if(MusicPlayers.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        
    }

    void Start()
    {

  
    }
}
