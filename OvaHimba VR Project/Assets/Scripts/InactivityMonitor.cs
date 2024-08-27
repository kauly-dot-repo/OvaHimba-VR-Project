using UnityEngine;
using System.Collections;

public class InactivityMonitor : MonoBehaviour
{
    public float inactivityThreshold = 10f; // Time in seconds to wait before performing the action
    public float checkInterval = 1f;        // How often to check for activity

    private float timeSinceLastActivity = 0f;

    private void Start()
    {
        StartCoroutine(CheckForInactivity());
    }

    private void Update()
    {
        // Detect activity (e.g., input or movement) and reset the timer
        if (DetectActivity())
        {
            timeSinceLastActivity = 0f;
        }
        else
        {
            timeSinceLastActivity += Time.deltaTime;
        }
    }

    private IEnumerator CheckForInactivity()
    {
        while (true)
        {
            // Wait for the specified check interval
            yield return new WaitForSeconds(checkInterval);

            // If time since last activity exceeds the threshold, perform the action
            if (timeSinceLastActivity >= inactivityThreshold)
            {
                PerformAction();
                timeSinceLastActivity = 0f; // Optionally reset the timer
            }
        }
    }

    private bool DetectActivity()
    {
        // Implement your logic to detect activity (e.g., user input, object movement, etc.)
        // Example: Detect user input or movement
        return Input.anyKey || (transform.position != Vector3.zero);
    }

    private void PerformAction()
    {
        // Implement the action to perform when inactivity is detected
        Debug.Log("No activity detected. Performing action.");
    }
}
