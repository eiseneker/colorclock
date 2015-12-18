using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour {

	public void Refresh(){
		GetComponent<Text>().text = PlayerPrefs.GetInt("HighScore", 0).ToString ();
	}
}
