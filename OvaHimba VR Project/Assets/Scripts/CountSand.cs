using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class CountSand : MonoBehaviour
{
    [SerializeField]
    public BoxCollider boxCollider; // Reference to the box collider
    public SceneTransitionManager sceneTransition;

    public List<GameObject> allSand;

    void Start()
    {
        allSand = new List<GameObject>(GameObject.FindGameObjectsWithTag("sand"));
    }

    void Update()
    {
        int count = CountObjectsTouchingBox();

        if (count >= allSand.Count)
        {
            Debug.Log("Number of objects touching the box: " + count);
            Debug.Log(
                "Not enough SAND COLLECTED yet: "
                    + "-----COLLECTED: "
                    + count
                    + "  ----ALL SAND: "
                    + allSand.Count
            );

            StartCoroutine(HandleCollisionWithDelay(count));
        }
    }

    public int CountObjectsTouchingBox()
    {
        // Get the exact bounds of the box collider
        Vector3 boxCenter = boxCollider.bounds.center;
        Vector3 boxSize = boxCollider.bounds.size;

        // Get all colliders overlapping the exact box area
        Collider[] colliders = Physics.OverlapBox(
            boxCenter,
            boxSize / 2,
            boxCollider.transform.rotation
        );

        int objectCount = 0;

        // Loop through the colliders and count those touching the box collider
        foreach (Collider collider in colliders)
        {
            // Ignore the box collider itself
            if (collider != boxCollider)
            {
                var col =
                    collider.gameObject.tag != null
                        ? collider.gameObject.tag
                        : collider.gameObject.name;
                XRBaseInteractable interactable =
                    collider.gameObject.GetComponent<XRBaseInteractable>();
                // Check if the collider is in contact with the box collider
                if (
                    collider.bounds.Intersects(boxCollider.bounds)
                    && collider.gameObject.tag == "SAND"
                    && !interactable.isSelected
                )
                {
                    Debug.Log("COLLIDER ------ " + col);
                    objectCount++;
                }
            }
        }

        return objectCount;
    }

    private IEnumerator HandleCollisionWithDelay(int count)
    {
        // Add the GameObject to the list immediately
        // treesChopped.Add(gameObject);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        // Log the immediate addition
        // Debug.Log("Added GameObject to list: " + gameObject.name);
        Debug.Log(
            "ALL SAND COLLECTED: "
                + "Number of objects touching the box BEFORE: "
                + count
                + "  ----ALL SAND: "
                + allSand.Count
        );

        // Wait for 10 seconds
        yield return new WaitForSeconds(5f);

        // Perform the delayed action here
        Debug.Log("5 seconds have passed since  ");

        sceneTransition.GoToSceneAsync(nextSceneIndex);
        // Additional actions can be placed here
    }
}
