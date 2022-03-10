using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    AudioClip[] musicLayers;
    [SerializeField]
    AudioSource audioSource;

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
        if (!audioSource)
        {
            audioSource = gameObject.GetComponentInParent<AudioSource>();
        }
        audioSource.clip = musicLayers[currentLayer];
        audioSource.Play();
    }

    public void Update()
    {
        if (audioSource.time >= 60)
        {
            PlayNextLayer();
        }
    }

    void PlayNextLayer() 
    {
        currentLayer++;
        currentLayer %= musicLayers.Length;

        audioSource.clip = musicLayers[currentLayer];
        audioSource.time = 0;

        audioSource.Play();
    }


}
