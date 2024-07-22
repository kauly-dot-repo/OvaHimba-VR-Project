using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;



public class ActivateSocketsOnGroundObjectAttachment : MonoBehaviour
{
    void Update()
    {
        // Find all game objects named "Snap zone (ground)" in the hierarchy
        GameObject[] groundSnapZones = GameObject.FindObjectsOfType<Transform>()
            .Where(t => t.name == "Snap zone (ground)")
            .Select(t => t.gameObject)
            .ToArray();

        foreach (GameObject groundZone in groundSnapZones)
        {
            // Get the XRSocketInteractor component from the ground zone
            XRSocketInteractor groundSocketInteractor = groundZone.GetComponent<XRSocketInteractor>();

            // Check if the ground socket has an object attached
            if (groundSocketInteractor != null && groundSocketInteractor.hasSelection)
            {
                // Find all game objects tagged "base" in the hierarchy
                GameObject[] baseZones = GameObject.FindGameObjectsWithTag("baseZone")
                    .ToArray();

                // Activate all wall sockets (now called base inter actors)
                foreach (GameObject baseZone in baseZones)
                {
                    XRSocketInteractor baseSocketInteractor = baseZone.GetComponent<XRSocketInteractor>();
                    if (baseSocketInteractor != null)
                    {
                        baseSocketInteractor.socketActive = true;
                    }
                }

                // Exit the loop after finding an attached object on a ground zone
                break;
            }

        } // END FOR EACH

        

    }
}
