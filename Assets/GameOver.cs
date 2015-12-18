using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	void Update(){
		transform.Find ("PointsText").GetComponent<Text>().text = GameController.points.ToString ();
	}

	public void TryAgain(){
		print ("huh");
		Application.LoadLevel("Game");
	}
}
