using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class healthCheck : MonoBehaviour {

	public MouseLook player;
	public TextMeshProUGUI txt;
	public TextMeshProUGUI sco;
	public spawnController score;
	private bool stop = false;

	// Use this for initialization
	void Start () {
		SceneManager.UnloadSceneAsync("title");
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = "Health: " + player.health;
		sco.text = "Score: " + score.score;
		if(player.alive == false){
			stop = true;
		}
	}

	void FixedUpdate(){
		if(stop == true){
			if(PlayerPrefs.HasKey("hi") == false){
				PlayerPrefs.SetInt("hi", score.score);
			}
			else{
				if(score.score > PlayerPrefs.GetInt("hi")){
					PlayerPrefs.SetInt("hi", score.score);
				}
			}
			PlayerPrefs.SetInt("score", score.score);
			SceneManager.LoadScene("title");
		}
	}
}
