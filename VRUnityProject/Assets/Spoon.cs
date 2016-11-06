using UnityEngine;
using System.Collections;

public class Spoon : MonoBehaviour 
{
	public Transform eggStart;

	private Vector3 startPosition;
	private Quaternion startQuaternion;
	private Transform startParent;

	public void Release ()
	{
		startPosition = eggStart.localPosition;
		startQuaternion = eggStart.localRotation;
		startParent = eggStart.parent;


		eggStart.parent = null;
		eggStart.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
	}

	public void Restart ()
	{
		UnityEngine.Debug.Log ("restart " + name);
		eggStart.gameObject.GetComponent<Rigidbody> ().isKinematic = true;

		eggStart.parent = startParent;
		eggStart.localPosition = startPosition;
		eggStart.localRotation = startQuaternion;

		eggStart.GetComponent<Eggs> ().SetLayer (8);
	}





	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
