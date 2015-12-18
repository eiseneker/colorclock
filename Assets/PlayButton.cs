using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	public void PlayGame(){
		Time.timeScale = 1;
		GameObject.Find ("HUDCanvas").transform.Find ("Start").gameObject.SetActive(false);
	}
}
