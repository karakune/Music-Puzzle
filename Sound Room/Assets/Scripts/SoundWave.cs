using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWave : MonoBehaviour
{

    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, 1f * speed);
    }

    void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.CompareTag("Outer Wall"))
		{
			Destroy(gameObject);
		}
        //if the object is actually a bouncer
        if (other.gameObject.tag.Contains("Bouncer "))
        {
            other.gameObject.GetComponent<AudioSource>().Play();

            //We're dropping this feature for now
            //Change the direction of the Sound Wave
            // transform.rotation = Quaternion.Euler(other.gameObject.GeComponent<SoundBouncer>().newRotation);
        }
    }
}
