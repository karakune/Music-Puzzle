using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reader : MonoBehaviour {

	public float speed;

	private Vector3 initialPosition;
	private bool isReading;

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		//FIXME: remove this
		Read();
	}
	
	// Update is called once per frame
	void Update () {
		if (isReading)
		{
			transform.Translate(0f, 0f, 1f * speed);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		// if (other.CompareTag("Wall Note"))
		// {
		// 	other.GetComponent<AudioSource>().Play();
		// }

		// if (other.CompareTag("Reader End"))
		// {
		// 	Reset();
		// }
	}

	public void Read()
	{
		isReading = true;
	}

	public void Reset()
	{
		transform.position = initialPosition;
		isReading = false;
	}
}
