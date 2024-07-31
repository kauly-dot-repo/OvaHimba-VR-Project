using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public FadeScreen fadeScreen;

    // public void GoToScene(int sceneIndex)
    // {
    //     StartCoroutine(GoToSceneRoutine(sceneIndex));
    // }

    // //Wait for fade screen to finish
    // IEnumerator GoToSceneRoutine(int sceneIndex)
    // {
    //     fadeScreen.FadeOut();
    //     //wait the duration of the fading
    //     yield return new WaitForSeconds(fadeScreen.fadeDuration);

    //     //Launch new scene
    //     SceneManager.LoadScene(sceneIndex); //easy
    //     //better but harder
    // }

    public void GoToSceneAsync(int sceneIndex)
    {
        StartCoroutine(GoToSceneAsyncRoutine(sceneIndex));
    }

    IEnumerator GoToSceneAsyncRoutine(int sceneIndex)
    {
        fadeScreen.FadeOut();

        // Launch the new scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        float timer = 0;

        while (timer <= fadeScreen.fadeDuration && !operation.isDone)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        operation.allowSceneActivation = true;
    }
}
