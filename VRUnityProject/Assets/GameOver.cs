using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public float duration = 0f;

	private float    startTime;
	public Transform startPosition;
	public Transform finalposition;
	public Image winImage;
	public Image looseImage;
	private bool hastomove = false;

	public bool endGameLaunch = false;

	public bool eggLeftLoose = false;
	public bool eggRightLoose = false;
		

	public  void LooseEgg(int index)
	{
		if (index == 0 && eggLeftLoose == false) {
			eggLeftLoose = true;
			if (eggRightLoose == true)
				End (false);
		}

		if (index == 1 && eggRightLoose == false) {
			eggRightLoose = true;
			if (eggLeftLoose == true)
				End (false);
		}
			
	}

	public void SpawnEnd () {
		End ((eggLeftLoose == false || eggRightLoose == false));
	}

	// Use this for initialization
	void Start () {
		startPosition.transform.parent = null;
		finalposition.transform.parent = null;
	}

	public void End(bool win)
	{
		if (endGameLaunch == true)
			return;
		endGameLaunch = true;

		winImage.enabled = win;
		looseImage.enabled = !win;
		hastomove = true;

        // Move to black room ?
        GameObject.Find("VR character").transform.position = new Vector3(67, 0, 0);
        Debug.Log("Moved the character to" + GameObject.Find("VR character").transform.position);


		GameObject.FindObjectOfType<MoveToParadise> ().EndGame (win);
		GameObject.FindObjectOfType<ObstacleSpawner> ().EndGame (win);
	}

	public void RestartGame()
	{
		endGameLaunch = false;
		winImage.enabled = false;
		looseImage.enabled = false;

		transform.position = startPosition.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (hastomove == true) {
			float t = (Time.time - startTime) / duration;

			transform.position = Vector3.Lerp (startPosition.position, finalposition.position, t);

			if (t >= 1f)
				hastomove = false;
		}
	}
}
