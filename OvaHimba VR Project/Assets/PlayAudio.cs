using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{

    public TriggerArea triggerArea;
    public AudioSource audioSource;
    
     void Start()
    {
        // Assign the PlayAudio method to the onTriggerEnter delegate
        triggerArea.onTriggerEnter += PlayAudioSource;
    }

    void PlayAudioSource(Collider other)
    {
        // Check if the audio is not already playing before calling Play
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
        
}
