using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class TreeChopping : MonoBehaviour
{
    [SerializeField]
    private int minHits = 2; // Minimum number of hits needed (inclusive)

    [SerializeField]
    private int maxHits = 5; // Maximum number of hits needed (inclusive)

    [SerializeField]
    private int requiredHits; // Number of hits needed to turn kinematic (adjust as needed)

    private int hitCount = 0;
    public List<GameObject> treesChopped;
    public List<GameObject> treesInScene;
    public int collisionCounter;

    public SceneTransitionManager sceneTransition;

    private void Start()
    {
        // Randomize requiredHits on Start
        // requiredHits = Random.Range(minHits, maxHits + 1);
        requiredHits = 4;

        treesInScene = new List<GameObject>(GameObject.FindGameObjectsWithTag("woodInteractable"));
    }

    void Update()
    {
        CheckTreesChopped();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb;
        // Check if the collided object has the tag "woodInteractable"
        if (collision.gameObject.CompareTag("woodInteractable"))
        {
            treesChopped.Add(collision.gameObject);
            // collisionCounter++;
            // Debug.Log("COLLISIONS" + collisionCounter);
            // Get the Rigidbody component of the collided object
            rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb == null)
            {
                rb = collision.gameObject.GetComponentInChildren<Rigidbody>();

                rb.isKinematic = false;
                // if (rb != null)
                // {
                hitCount = collision.contactCount;

                if (hitCount >= requiredHits)
                {
                    // Turn on the kinematic property after enough hits
                    rb.isKinematic = false;

                    var grabbableObject = collision.gameObject.GetComponent<XRGrabInteractable>();
                    if (grabbableObject != null)
                    {
                        // Set the XR Grab Interactable script to active
                        grabbableObject.enabled = true;
                    }
                }
                // }
            }
            else
            {
                rb.isKinematic = false;
            }
        }
    }

    private void CheckTreesChopped()
    {
        treesChopped = new List<GameObject>();
        if (treesChopped != null)
        {
            foreach (GameObject go in treesInScene)
            {
                Rigidbody rb = go.GetComponent<Rigidbody>();
                if (rb != null && !rb.isKinematic)
                {
                    treesChopped.Add(go);
                    if (treesChopped.Count >= 3)
                    {
                        Debug.Log("All Trees Chopped");
                        StartCoroutine(HandleCollisionWithDelay());
                        // int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                        // int nextSceneIndex = currentSceneIndex + 1;
                        // sceneTransition.GoToSceneAsync(nextSceneIndex);
                    }
                    else
                    {
                        Debug.Log(
                            "Not enough trees chopped yet: "
                                + "-----CHOPPED: "
                                + treesChopped.Count
                                + "  ----ALL Trees: "
                                + treesInScene.Count
                        );
                    }
                }
            }
        }
        else
        {
            Debug.Log(
                "NOOO Trees Chopped YET"
                    + "-----CHOPPED: "
                    + treesChopped.Count
                    + "  ----ALL Trees: "
                    + treesInScene.Count
            );
        }
    }

    private IEnumerator HandleCollisionWithDelay()
    {
        // Add the GameObject to the list immediately
        // treesChopped.Add(gameObject);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        // Log the immediate addition
        // Debug.Log("Added GameObject to list: " + gameObject.name);
        Debug.Log("-----CHOPPED: " + treesChopped.Count + "  ----ALL Trees: " + treesInScene.Count);

        // Wait for 10 seconds
        yield return new WaitForSeconds(5f);

        // Perform the delayed action here
        Debug.Log(
            "5 seconds have passed since the number of trees CHOPPED was: " + treesChopped.Count
        );

        sceneTransition.GoToSceneAsync(nextSceneIndex);
        // Additional actions can be placed here
    }
}
