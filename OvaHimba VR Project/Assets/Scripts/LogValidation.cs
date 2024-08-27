using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class LogValidation : MonoBehaviour
{
    [SerializeField]
    private List<XRSocketInteractor> socketsList;

    public SceneTransitionManager sceneTransition;

    void Start()
    {
        socketsList = new List<XRSocketInteractor>(GetComponentsInChildren<XRSocketInteractor>());
    }

    void Update()
    {
        DebugSocketStates();
        CheckSocketSelected();
    }

    private void CheckSocketSelected()
    {
        if (AllSocketsHaveSelection())
        {
            Debug.Log(AllSocketsHaveSelection() + " ALL sockets have a selection!!!!");

            StartCoroutine(HandleCollisionWithDelay(socketsList));
        }
        else
        {
            Debug.Log(AllSocketsHaveSelection() + " Not all sockets have a selection.");
        }
    }

    private void DebugSocketStates()
    {
        Debug.Log(socketsList.Count);
        foreach (XRSocketInteractor socket in socketsList)
        {
            Debug.Log(socket.name + " hasSelection: " + socket.hasSelection);
        }
    }

    bool AllSocketsHaveSelection()
    {
        foreach (XRSocketInteractor socket in socketsList)
        {
            Debug.Log($"Socket: {socket.name}, hasSelection: {socket.hasSelection}");
            if (!socket.hasSelection)
            {
                return false;
            }
        }
        return true;
    }

    private IEnumerator HandleCollisionWithDelay(List<XRSocketInteractor> socketsList)
    {
        // Add the GameObject to the list immediately
        // treesChopped.Add(gameObject);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        // Log the immediate addition
        Debug.Log("Added GameObject to list: " + socketsList);

        // Wait for 10 seconds
        yield return new WaitForSeconds(5f);

        // Perform the delayed action here
        Debug.Log("5 seconds have passed since  ");

        sceneTransition.GoToSceneAsync(nextSceneIndex);
        // Additional actions can be placed here
    }
}
