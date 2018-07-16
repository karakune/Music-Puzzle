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
    }
}
