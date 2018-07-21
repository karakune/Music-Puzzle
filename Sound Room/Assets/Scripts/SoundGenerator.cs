using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGenerator : MonoBehaviour {

	public float timeBetweenSpawns;
	public GameObject soundWavePrefab;
	public Vector3 soundWaveSpawnLocation;

	private bool isSpawningSoundWave = true;


	// Use this for initialization
	void Start () {
		
		InvokeRepeating("SpawnSoundWave", 0, timeBetweenSpawns);
	}

	public void SpawnSoundWave()
	{
		if(isSpawningSoundWave)
		Instantiate(soundWavePrefab, transform.position + soundWaveSpawnLocation, new Quaternion(), transform);
	}

	public void ChangeIsSpawningSoundWave(){

		if (isSpawningSoundWave)
			isSpawningSoundWave = false;
			else
			isSpawningSoundWave = true;
	}

	public void ForceSpawnSoundWave()
	{
		Instantiate(soundWavePrefab, transform.position + soundWaveSpawnLocation, new Quaternion(), transform);
	}
}
