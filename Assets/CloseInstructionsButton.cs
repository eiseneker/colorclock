using UnityEngine;
using System.Collections;

public class CloseInstructionsButton : MonoBehaviour {

	public void Close(){
		GameObject.Find ("HUDCanvas").transform.Find ("HowToPlay").gameObject.SetActive (false);
	}
}
