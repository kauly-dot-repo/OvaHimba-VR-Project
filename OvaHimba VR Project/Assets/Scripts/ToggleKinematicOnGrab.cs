using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleKinematicOnGrab : MonoBehaviour
{
    private Rigidbody rigidBody;
    private XRBaseInteractor grabbingInteractor;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        MakeKinematic(); // Make the object kinematic initially
    }

    // private void OnEnable()
    // {
        
    //     XRBaseInteractor.SelectEntering += OnSelectEntering;
    //     XRBaseInteractor.OnSelectExiting += OnSelectExiting;
    // }

    // private void OnDisable()
    // {
    //     XRBaseInteractor.OnSelectEntering -= OnSelectEntering;
    //     XRBaseInteractor.OnSelectExiting -= OnSelectExiting;
    // }

    private void OnSelectEntering(SelectEnterEventArgs args)
    {
        // grabbingInteractor = args.interactor;
        MakeDynamic(); // Make the object dynamic when grabbed
    }

    // private void OnSelectExiting(SelectExitEventArgs args)
    // {
    //     if (args.interactor == grabbingInteractor)
    //     {
    //         grabbingInteractor = null;
    //         MakeKinematic(); // Make the object kinematic again when released
    //     }
    // }

    private void MakeKinematic()
    {
        if (rigidBody != null)
        {
            rigidBody.isKinematic = true;
        }
    }

    private void MakeDynamic()
    {
        if (rigidBody != null)
        {
            rigidBody.isKinematic = false;
            rigidBody.velocity = Vector3.zero; // Reset velocity to prevent unintended movement
            rigidBody.angularVelocity = Vector3.zero; // Reset angular velocity to prevent spinning
        }
    }
}
