using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	Clock currentClock;
	Clock previousClock;
	Transform canvas;
	GameObject spawnPoint;
	bool inSwappedState;
	float timeSinceLastClock;
	bool gameIsOver;
	public static float difficulty;
	
	public GameObject clockPrefab;
	public GameObject gameOverPrefab;
	
	public static int points;
	public static bool firstLoad = true;
	

	// Use this for initialization
	void Start () {
		GameObject.Find ("HUDCanvas").transform.Find ("Start").gameObject.SetActive (true);
		GameObject.Find ("HUDCanvas").transform.Find ("Start").Find ("PointsText").GetComponent<HighScoreText>().Refresh();
		Time.timeScale = 0;
		
		points = 0;
		difficulty = .3f;
		
		int randomIndex = Random.Range (0, 6);
	
		canvas = GameObject.Find ("MainCanvas").transform;
		spawnPoint = canvas.Find ("SpawnPoint").gameObject;
		
		GenerateNewCurrentClock(randomIndex);
		GameObject.Find ("HUDCanvas").transform.Find ("GameOver").gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(points < 10){
			difficulty = .5f;
		}else if(points < 20){
			difficulty = .6f;
		}else if(points < 30){
			difficulty = .7f;
		}else if(points < 40){
			difficulty = .8f;
		}else if(points < 50){
			difficulty = .9f;
		}else if (points < 80){
			difficulty = 1;
		}else if (points < 120){
			difficulty = 1.2f;
		}else if (points < 140){
			difficulty = 1.4f;
		}else if (points < 160) {
			difficulty = 1.6f;
		}else if (points < 180) {
			difficulty = 1.8f;
		}else{
			difficulty = 2;
		}
		if(!gameIsOver){
			if(currentClock.finished){
				if(inSwappedState){
					EnterGameOver();
				}else{
					if(previousClock != null) Destroy (previousClock.gameObject);
					previousClock = currentClock;
					GenerateNewCurrentClock(previousClock.colorIndex);
				}
			}
			
			timeSinceLastClock += Time.deltaTime;
			
			if(previousClock != null && Input.GetMouseButtonDown(0) && timeSinceLastClock > .1f){
				Fire();
			}
		}
	}
	
	void GenerateNewCurrentClock(int colorIndex){
		if(previousClock != null && Random.value < .2){
			inSwappedState = true;
		}else{
			inSwappedState = false;
		}
		
		int newColor = colorIndex + 1;
		
		if(inSwappedState){
			int increment = Random.Range (1, 5);
			newColor += increment;
		}
		
		if(newColor > 5){
			newColor = newColor - 6;
		}
		
		GameObject clockObject = Instantiate (clockPrefab, spawnPoint.transform.position, Quaternion.identity) as GameObject;
		currentClock = clockObject.GetComponent<Clock>();
		currentClock.colorIndex = newColor;
		currentClock.transform.parent = canvas;
		timeSinceLastClock = 0;
		
		points++;
	}
	
	void Fire(){
		if(inSwappedState){
			Destroy(currentClock.gameObject);
			GenerateNewCurrentClock (previousClock.colorIndex);
		}else{
			EnterGameOver();
		}
	}

	void EnterGameOver(){
		print ("hi score: " + PlayerPrefs.GetInt("HighScore", 0));
		if(PlayerPrefs.GetInt("HighScore", 0) < points){
			print ("setting new high score");
			PlayerPrefs.SetInt("HighScore", points);
		}
		
		gameIsOver = true;
		GameObject.Find ("HUDCanvas").transform.Find ("GameOver").gameObject.SetActive (true);
		Time.timeScale = 0;
	}	
}
