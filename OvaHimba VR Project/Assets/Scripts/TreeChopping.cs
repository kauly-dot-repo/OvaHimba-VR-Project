using UnityEngine;

public class TreeChopping : MonoBehaviour
{
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
                // Turn off the kinematic property
                rb.isKinematic = false;

                // Optionally, you can also enable gravity if needed
                // rb.useGravity = true;
            }
        }
    }
}
