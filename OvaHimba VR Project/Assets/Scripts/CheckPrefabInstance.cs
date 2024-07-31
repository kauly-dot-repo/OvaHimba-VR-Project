using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPrefabInstance : MonoBehaviour
{
    public string targetPrefabName; // Set this to the prefab's name

    private void OnCollisionEnter(Collision collision)
    {
        // Get the PrefabIdentifier component from the collision object
        PrefabIdentifier identifier = collision.gameObject.GetComponent<PrefabIdentifier>();

        // Check if the component exists and its name matches
        if (identifier != null && identifier.prefabName == targetPrefabName)
        {
            Debug.Log("Collision object is an instance of the target prefab.");
        }
        else
        {
            Debug.Log("Collision object is not an instance of the target prefab.");
        }
    }
}
