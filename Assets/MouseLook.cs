using UnityEngine;
using System.Collections;

// Script by IJM: http://answers.unity3d.com/questions/29741/mouse-look-script.html
// Changed to fit standard C# conventions
 
// MouseLook rotates the transform based on the mouse delta.
// Minimum and Maximum values can be used to constrain the possible rotation
 
// To make an FPS style character:
// - Create a capsule.
// - Add a rigid body to the capsule
// - Add the MouseLook script to the capsule.
// -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
// - Add FPSWalker script to the capsule
 
/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
/// -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {
	 
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, 	MouseY = 2 };
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	 
	public float minimumX = -360F;
	public float maximumX = 360F;
	 
	public float minimumY = -60F;
	public float maximumY = 60F;

	private float defX = 0f;
	private float defY = 0f;
	private float ang = 0f;
	private float diff = 0f;
	private bool shooting = false;
	public float deadzone = 2f;
	public Vector3 offset;
	public float bulletVel = 10f;
	public Transform gun;
	public bool alive = true;
	public float health = 100f;

	public Transform player;
	public GameObject bullet;
	 
	float rotationX = 0F;
	float rotationY = 0F;
	 
	Quaternion originalRotation;
	 
	void Update()
	{
		defX = defX + Input.GetAxis("Mouse X");
		defY = defY + Input.GetAxis("Mouse Y");
		ang = Mathf.Atan2(defY, defX) * Mathf.Rad2Deg;
		player.rotation = Quaternion.Euler(0f, 90 + ang, 0f);
		//Debug.Log(diff + ang);
		//Debug.Log(defX + ", " + defY);
		if(Mathf.Sqrt(Mathf.Pow(defX, 2) + Mathf.Pow(defY, 2)) > deadzone){
			shooting = true;
		}
		else{
			shooting = false;
		}
		if(health <= 0){
			alive = false;
		}
	}

	Vector3 getVel(){
		float y = bulletVel * Mathf.Cos(((90 + ang)) / Mathf.Rad2Deg);
		float x = bulletVel * Mathf.Sin(((90 + ang)) / Mathf.Rad2Deg);
		Vector3 output = new Vector3(x, 0, y);
		return output;
	}

	IEnumerator shoot(){
		while(alive == true){
			if(Mathf.Sqrt(Mathf.Pow(defX, 2) + Mathf.Pow(defY, 2)) > deadzone){
				GameObject obj = (GameObject) Instantiate(bullet, gun.position, player.rotation);
				obj.GetComponent<Rigidbody>().velocity = getVel();
				//Debug.Log(player.position.y + ", " + gun.position.y);
				//Debug.Log("pew");
			}
			yield return new WaitForSeconds(0.1f);
		}
	}
	 
	void Start()
	{
		StartCoroutine("shoot");
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "zombie"){
			health = health - 10;
		}
	}
}