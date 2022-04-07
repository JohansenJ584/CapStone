using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCreatureSound : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] List<AudioClip> gruntSounds = new List<AudioClip>();
    void Start()
    {
        InvokeRepeating("MakeSound", 1f, 4.73f);
    }

    //The method I'm calling on Update
    void MakeSound()
    {
        if (Random.Range(0.0f, 100.0f) < 5f)
        {
            _audioSource.clip = gruntSounds[Random.Range(0, gruntSounds.Count)];
            _audioSource.Play();
        }

    }
}
