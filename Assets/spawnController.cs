using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnController : MonoBehaviour {

	public GameObject modelZombie;
	private bool canSpawn;
	public Vector3[] spawnPoints;
	private int count;
	public int max;
	public int score = 0;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < spawnPoints.Length; i++){
			Instantiate(modelZombie, spawnPoints[i], Quaternion.Euler(0, 0, 0));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if((GameObject.FindGameObjectsWithTag("zombie").Length <= spawnPoints.Length)){
			canSpawn = true;
			count = count + 1;
		}
		if(canSpawn == true){
			canSpawn = false;
			int rng = Random.Range(0, spawnPoints.Length);
			Instantiate(modelZombie, spawnPoints[rng], Quaternion.Euler(0, 0, 0));
			score = score + 2;
		}
	}
}
