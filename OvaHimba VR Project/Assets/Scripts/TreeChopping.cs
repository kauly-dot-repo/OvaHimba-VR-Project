using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChopping : MonoBehaviour
{
    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        MakeKinematic(); // Make the object kinematic initially
    }

    private void OnCollisionEnter(Collision collision) //detecting collisions
    {
        //collision var contains info about object collided with
        if(collision.gameObject.tag == "woodInteractable"){
            MakeDynamic();
        }        
    }

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
