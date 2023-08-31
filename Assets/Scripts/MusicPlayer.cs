using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        int numOfAudioSourceInstance = FindObjectsOfType<AudioSource>().Length;
        if (numOfAudioSourceInstance > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
