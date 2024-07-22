using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketActivationManager : MonoBehaviour
{
    [Tooltip("Tags of all socket groups in activation order")]
    public string[] socketGroupTags;

    private void Awake()
    {
        // No need for a separate dictionary as we can directly use the tags array
    }

    private void Update()
    {
        int currentGroupIndex = 0;

        while (currentGroupIndex < socketGroupTags.Length)
        {
            string currentTag = socketGroupTags[currentGroupIndex];

            // Check if all sockets in the current group (or with the current tag) are selected
            if (IsGroupSelected(currentTag))
            {
                // Deactivate the current group once all the sockets have a selection
                // DeactivateSockets(currentTag);
                // Activate sockets for the next group (if it exists)
                ActivateNextGroup(currentGroupIndex);
                currentGroupIndex++; // Move to the next group or tag
            }

            else
            {
                break; // Exit loop if any socket in the current group is not selected
            }
        
        }
         
    }

    private bool IsGroupSelected(string groupTag)
    {
        // Find all sockets with the group tag
        var sockets = FindObjectsOfType<XRBaseInteractor>(true)
            .Where(socket => socket.gameObject.CompareTag(groupTag))
            .ToList();

        // Check if any socket in the list is not selected
        return !sockets.Any(socket => !socket.hasSelection);
    }

    private void ActivateNextGroup(int currentGroupIndex)
    {
        if (currentGroupIndex < socketGroupTags.Length - 1)
        {
            string nextGroupTag = socketGroupTags[currentGroupIndex + 1];
            ActivateSockets(nextGroupTag);
        }
    }

    private void ActivateSockets(string nextGroupTag)
    {
        // Find and activate sockets with the next group tag
        var sockets = FindObjectsOfType<XRBaseInteractor>(true);
        foreach (var socket in sockets)
        {
            if (socket.gameObject.CompareTag(nextGroupTag))
            {
                socket.gameObject.SetActive(true);
            }
        }
    }

    private void DeactivateSockets(string currentTag)
    {
        // Find and activate sockets with the next group tag
        var sockets = FindObjectsOfType<XRBaseInteractor>(true);
        foreach (var socket in sockets)
        {
            if (socket.gameObject.CompareTag(currentTag))
            {
                socket.gameObject.SetActive(false);
            }
        }
    }
}
