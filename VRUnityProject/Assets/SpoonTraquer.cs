using UnityEngine;
using System.Collections;

public class SpoonTraquer : MonoBehaviour {

	public GameObject spoon;
	public GameObject attach;

	public Transform content;

	// Use this for initialization
	IEnumerator Start () 
	{
		yield return new WaitForSeconds (1f);

		spoon.transform.parent				= attach.transform;
		spoon.transform.localPosition		= new Vector3(0F,-0.03F,0.12F);
		spoon.transform.localEulerAngles	= new Vector3 (0f, -90f, -12f);

		spoon.transform.parent = null;

		FixedJoint joint = spoon.AddComponent<FixedJoint>();
		spoon.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		joint.connectedBody = attach.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
