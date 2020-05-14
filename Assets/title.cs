using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class title : MonoBehaviour {

	public TextMeshProUGUI hi;
	public TextMeshProUGUI sco;
	private bool restart = false;

	// Use this for initialization
	void Start () {
		SceneManager.UnloadSceneAsync("title");
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.HasKey("score") == false){
			sco.text = " ";
		}
		else{
			sco.text = "Score: " + PlayerPrefs.GetInt("score");
		}
		if(PlayerPrefs.HasKey("hi") == false){
			hi.text = " ";
		}
		else{
			hi.text = "HiScore: " + PlayerPrefs.GetInt("hi");
		}
		if(Input.GetButtonDown("jump")){
			restart = true;
		}
	}

	void FixedUpdate(){
		if(restart == true){
			SceneManager.LoadScene("game");
		}
	}
}
