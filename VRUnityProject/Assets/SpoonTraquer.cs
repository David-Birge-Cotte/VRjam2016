using UnityEngine;
using System.Collections;

public class SpoonTraquer : MonoBehaviour {

	public GameObject spoon;
	public GameObject attach;


	// Use this for initialization
	IEnumerator Start () 
	{
		yield return new WaitForSeconds (2f);
		FixedJoint joint = spoon.AddComponent<FixedJoint>();
		spoon.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		spoon.transform.position = attach.transform.position;
		joint.connectedBody = attach.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
