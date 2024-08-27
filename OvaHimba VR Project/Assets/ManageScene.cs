using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    public AudioSource audioSource; // Assign this in the Inspector
    // public AudioClip audioClip; // Assign this in the Inspector

    // private int playCount = 0;
    // private bool isAudioPlaying = false;
    public SceneTransitionManager sceneTransitionManager;

    public TriggerArea triggerArea1;
    public TriggerArea triggerArea2;

    

    private void Update()
    {
        // Check if the audio has played three times
        
            // triggerArea1.onTriggerEnter += sceneTransitionManager.GoToSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        

        
    }

    
}
