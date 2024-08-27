using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DungAmount : MonoBehaviour
{
    public List<GameObject> allDung;

    // Start is called before the first frame update
    void Start()
    {
        // allDung = new List<GameObject>(GameObject.FindGameObjectsWithTag("dung"));
        int count = allDung.Count != 0 ? allDung.Count : 0;
        Debug.Log("STARTING WITH  " + count + " Dung IN TOTAL");
    }

    // Update is called once per frame
    void Update()
    {
        DungCollected();
    }

    public void DungCollected()
    {
        allDung.Clear();
        allDung = new List<GameObject>(GameObject.FindGameObjectsWithTag("dung"));
        // Debug.Log("There IS " + allDung.Count + " Dung IN TOTAL");
    }
}
