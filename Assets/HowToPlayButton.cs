using UnityEngine;
using System.Collections;

public class HowToPlayButton : MonoBehaviour {

	public void ShowInstructions(){
		GameObject.Find ("HUDCanvas").transform.Find ("HowToPlay").gameObject.SetActive (true);
	}
}
