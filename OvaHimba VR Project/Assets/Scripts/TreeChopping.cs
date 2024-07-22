using UnityEngine;
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

    private void Start()
    {
        // Randomize requiredHits on Start
        requiredHits = Random.Range(minHits, maxHits + 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the tag "woodInteractable"
        if (collision.gameObject.CompareTag("woodInteractable"))
        {
            // Get the Rigidbody component of the collided object
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            // Check if the Rigidbody component exists
            if (rb != null)
            {
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
            }
        }
    }
}
