using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    AudioClip[] musicLayers;
    [SerializeField]
    AudioSource audioSource;

    double startTime;

    int currentLayer = 0;

    #region Singleton

    public static MusicManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    #endregion Singleton

    public void Start() 
    {
        audioSource.time = 0;
        audioSource.clip = musicLayers[currentLayer];
        audioSource.Play();
    }

    public void Update()
    {
        if (audioSource.time >= 60 || !audioSource.isPlaying)
        {
            audioSource.Pause();
            currentLayer = (currentLayer + 1) % musicLayers.Length;
            audioSource.clip = musicLayers[currentLayer];
            audioSource.time = 0;
            audioSource.UnPause();
            audioSource.Play();
        }


    }



}
