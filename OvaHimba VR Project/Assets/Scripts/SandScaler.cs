using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandScaler : MonoBehaviour
{
    public GameObject objectToSpawn; // The object to spawn
    public GameObject bucketSand;

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision with" + other.gameObject.name);
        //     if (!objectToSpawn.activeSelf && other.CompareTag("sand"))
        //     {
        //         objectToSpawn.SetActive(true);
        //         other.transform.localScale += objectToSpawn.transform.localScale;
        //     }
        //     else if (objectToSpawn.activeSelf && other.CompareTag("sand"))
        //     {
        //         objectToSpawn.SetActive(false);
        //         // other.transform.localScale -= objectToSpawn.transform.localScale;
        //     }
        //     else if (objectToSpawn.activeSelf && other.CompareTag("bucket"))
        //     {
        //         objectToSpawn.SetActive(false);
        //         bucketSand.transform.localScale -= objectToSpawn.transform.localScale;
        //     }
        //     else
        //     { //not objectToSpawn.activeSelf && other.CompareTag("bucket")
        //         objectToSpawn.SetActive(false);
        //     }
    }
}
