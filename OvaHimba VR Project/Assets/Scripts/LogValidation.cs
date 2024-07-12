using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LogValidation : MonoBehaviour
{
    // public string targetTag = "woodInteractable"; // Replace with your desired tag
    public XRSocketInteractor socketInteractor;

    void OnCollisionEnter(Collision collision)
    {
        string collidedObjectTag = collision.gameObject.tag;

        // Print the tag to the console
        Debug.Log("Collided with object tag: " + collidedObjectTag);
    }
}
