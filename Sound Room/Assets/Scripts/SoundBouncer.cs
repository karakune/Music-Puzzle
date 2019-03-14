using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBouncer : MonoBehaviour
{
    // public Vector3 newRotation;
    
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Killzone"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = initialPosition;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
