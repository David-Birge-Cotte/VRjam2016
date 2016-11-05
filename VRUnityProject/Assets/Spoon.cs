using UnityEngine;
using System.Collections;

public class Spoon : MonoBehaviour 
{
	public Transform eggStart;


	public void Release ()
	{
		eggStart.parent = null;
		eggStart.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
