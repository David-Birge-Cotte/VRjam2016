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
		startPosition = transform.localPosition;
		startQuaternion = transform.localRotation;
		startParent = transform.parent;


		eggStart.parent = null;
		eggStart.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
	}

	public void Restart ()
	{
		eggStart.gameObject.GetComponent<Rigidbody> ().isKinematic = true;

		transform.parent = startParent;
		transform.localPosition = startPosition;
		transform.localRotation = startQuaternion;

		eggStart.GetComponent<Eggs> ().SetLayer (8);
	}





	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
