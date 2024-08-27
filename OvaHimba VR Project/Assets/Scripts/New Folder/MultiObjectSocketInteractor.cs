using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MultiObjectSocketInteractor : XRSocketInteractor
{
    // List to hold multiple interactables
    private List<IXRSelectInteractable> interactables = new List<IXRSelectInteractable>();

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        // Add the interactable to the list
        interactables.Add(args.interactableObject);

        // Ensure that the base implementation is not called, to prevent it from deselecting others
    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        // Remove the interactable from the list
        interactables.Remove(args.interactableObject);

        // Optionally destroy the object when it's removed
        // Destroy(args.interactableObject.gameObject);
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        // Always allow selection if it's not already in the list
        return !interactables.Contains(interactable);
    }
}
