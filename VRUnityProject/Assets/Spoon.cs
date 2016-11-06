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
			
		StartCoroutine (RePosEgg ());
	}


	IEnumerator RePosEgg (){
		eggStart.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		eggStart.gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		eggStart.GetComponent<Eggs> ().meshCollider.isTrigger = true;
		eggStart.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;

		yield return new WaitForSeconds (0.1f);

		eggStart.GetComponent<Eggs> ().SetLayer (8);

		yield return new WaitForSeconds (0.1f);

		eggStart.parent = startParent;
		eggStart.localPosition = startPosition;
		eggStart.localRotation = startQuaternion;

		eggStart.GetComponent<Eggs> ().meshCollider.isTrigger = false;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
