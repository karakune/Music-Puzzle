using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBouncer : MonoBehaviour
{
    public AudioSource note;
    public Vector3 newRotation;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        // if (other.CompareTag("Sound Wave"))
        // {
        //     note.Play();
        //     //Change the direction of the Sound Wave
        //     other.transform.rotation = Quaternion.Euler(newRotation);
        // }
    }
}
