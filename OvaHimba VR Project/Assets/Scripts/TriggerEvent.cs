using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField] UnityEvent<GameObject> onTriggerEnter;
    [SerializeField] UnityEvent<GameObject> onTriggerExit;

    void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke(other.gameObject);
        
    }

    void OnTriggerExit(Collider other)
    {
        onTriggerExit.Invoke(other.gameObject);
    }
}
