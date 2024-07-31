using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerArea : MonoBehaviour
{
    public delegate void TriggerEventDelegate(Collider other);
    public TriggerEventDelegate onTriggerEnter;
    public TriggerEventDelegate onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerExit?.Invoke(other);   

    }

}
