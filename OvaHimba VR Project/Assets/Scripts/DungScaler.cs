using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DungScaler : MonoBehaviour
{
    public GameObject currentObject;

    void Start()
    {
        currentObject = this.gameObject;
        Debug.Log("Current Object" + currentObject.name);
    }

    public void ChangeToCollected()
    {
        currentObject.tag = null;
    }

    public void ChangeToDung()
    {
        currentObject.tag = "dung";
    }
}
