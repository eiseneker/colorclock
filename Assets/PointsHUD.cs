using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PointsHUD : MonoBehaviour {
	Text text;
	public GameObject gameControllerObject;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = GameController.points.ToString();
	}
}
