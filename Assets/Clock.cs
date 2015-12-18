using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Clock : MonoBehaviour {

	public int colorIndex;
	private Color[] colors = {
		Color.red,
		new Color(1, .5f, 0),
		Color.yellow,
		Color.green,
		Color.blue,
		new Color(1, 0, 1)
	};

	public bool finished;
	Image image;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
		image.fillAmount = 0;
		
		image.color = colors[colorIndex];
	}
	
	// Update is called once per frame
	void Update () {
		image.fillAmount += Time.deltaTime * GameController.difficulty;
		
		if(image.fillAmount >= 1){
			finished = true;
		}
	}
}
