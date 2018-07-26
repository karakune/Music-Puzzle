using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] noteAreas;
	public bool isGameOver;
	public TextMesh chronometer;

    // Use this for initialization
    void Start()
    {
        noteAreas = GameObject.FindGameObjectsWithTag("Note Area");
		isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (!isGameOver)
		{
			chronometer.text = Time.time.ToString("F2");
		}
    }

	public void AnnounceVictory()
	{
		//make sure no more victories will be announced
		isGameOver = true;
		GameObject[] soundWaves = GameObject.FindGameObjectsWithTag("Sound Wave");
		foreach(GameObject sw in soundWaves)
		{
			Destroy(sw);
		}
		GetComponent<AudioSource>().Play();
	}
}
