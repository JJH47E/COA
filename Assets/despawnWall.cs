﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawnWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "bullet"){
			//Debug.Log("hit");
			Destroy(col.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
