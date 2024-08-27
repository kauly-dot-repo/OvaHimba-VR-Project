using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoppedTreeCounter : MonoBehaviour
{
    // public int branchesChopped;
    public int requiredWoodAmount;
    public TreeChopping treechopped;

    public SceneTransitionManager sceneTransitionManager;


    // Update is called once per frame
    void Update()
    {
        CheckTreeChopped();
    }

    public void CheckTreeChopped()
    {
        // Get all the wood pieces into
        GameObject[] allWoodArray = GameObject.FindGameObjectsWithTag("woodInteractable");
        // List<GameObject> allWoodList = new List<GameObject>(allWoodArray);

        List<GameObject> choppedWoodList = new List<GameObject>();
        foreach (GameObject wood in allWoodArray)
        {
            if (!wood.GetComponent<Rigidbody>().isKinematic || !wood.GetComponentInChildren<Rigidbody>().isKinematic)
            {
                choppedWoodList.Add(wood);
                if (choppedWoodList.Count == requiredWoodAmount)
                {
                    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                    sceneTransitionManager.GoToSceneAsync(currentSceneIndex + 1);
                }
            }
        }
    }

    // public void giveHint()
}
