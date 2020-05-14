using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour {

	public float health = 20;
	public Transform player, self;
	public float moveSpeed = 3f;
	public Rigidbody selfPhys;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "bullet"){
			Debug.Log("hit");
			Destroy(col.gameObject);
			health = health - 10;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	Vector3 calcVel(){
		float dx = player.position.x - self.position.x;
		float dy = player.position.z - self.position.z;
		float ang = Mathf.Atan2(dx, dy);
		float y = moveSpeed * Mathf.Cos(ang);
		float x = moveSpeed * Mathf.Sin(ang);
		//Debug.Log(Mathf.Sin(ang));
		//Debug.Log(Mathf.Cos(ang));
		Vector3 output = new Vector3(x, 0, y);
		return output;
	}

	void FixedUpdate(){
		if(health <= 0){
			Destroy(gameObject);
		}
		selfPhys.velocity = calcVel();
		//Debug.Log(calcVel());
	}
}
