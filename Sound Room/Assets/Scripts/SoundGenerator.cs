using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGenerator : MonoBehaviour {

	public float timeBetweenSpawns;
	public GameObject soundWavePrefab;
	public Vector3 soundWaveSpawnLocation;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnSoundWave", 0, timeBetweenSpawns);
	}

	void SpawnSoundWave()
	{
		Instantiate(soundWavePrefab, transform.position + soundWaveSpawnLocation, new Quaternion(), transform);
	}
}
