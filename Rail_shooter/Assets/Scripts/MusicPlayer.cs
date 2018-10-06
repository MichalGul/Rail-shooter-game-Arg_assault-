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
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {

        startUpSound = GetComponent<AudioSource>();
        startUpSound.PlayOneShot(startUpClip);

    }
}
