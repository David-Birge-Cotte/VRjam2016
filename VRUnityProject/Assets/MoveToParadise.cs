using UnityEngine;
using System.Collections;

public class MoveToParadise : MonoBehaviour {

	public Transform character;
	public Transform paradise;

	public float duration = 0f;

	private float    startTime;
	private Vector3 startPosition;
	private bool hastomove = false;

	public void Start (){
		StartToMove ();
	}

	// Use this for initialization
	public void StartToMove () 
	{
		startTime = Time.time;
		startPosition = character.position;
		hastomove = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (hastomove == false) 
		{
			return;
		}

		float t = (Time.time - startTime) / duration;

		character.transform.position = Vector3.Lerp (startPosition, paradise.position, t);

		if (t >= 1f) 
		{
			hastomove = false;

			SpoonTraquer[] spoonTraquers = GameObject.FindObjectsOfType<SpoonTraquer> ();
			foreach (SpoonTraquer sp in spoonTraquers)
				sp.AddEgg ();

			StartCoroutine (StartGame ());
		}
	}

	IEnumerator StartGame ()
	{
		yield return new WaitForSeconds (2f);

		GameObject.FindObjectOfType<ObstacleSpawner> ().StartGame ();
	}
}
