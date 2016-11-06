using UnityEngine;
using System.Collections;

public class SpoonTraquer : MonoBehaviour {

	public GameObject spoon;
	public GameObject attach;

	public Transform content;

	public SteamVR_RenderModel deviceModel;

	public void AddEgg ()
	{
		StartCoroutine (StartEgg ());
	}


	void Update ()
	{
		var device = SteamVR_Controller.Input((int)deviceModel.index);

		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) 
		{
			Debug.Log ("Trigger");
			GameObject.FindObjectOfType<MoveToParadise> ().StartIntro ();
		}

		if (Input.GetKeyDown(KeyCode.S))
			GameObject.FindObjectOfType<MoveToParadise> ().StartIntro ();
	}

	// Use this for initialization
	IEnumerator StartEgg () 
	{
		yield return new WaitForSeconds (1f);

		spoon.transform.parent				= attach.transform;
		spoon.transform.localPosition		= new Vector3(0F,-0.03F,0.12F);
		spoon.transform.localEulerAngles	= new Vector3 (0f, -90f, -12f);

		spoon.transform.parent = null;

		FixedJoint joint = spoon.AddComponent<FixedJoint>();
		spoon.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		joint.connectedBody = attach.GetComponent<Rigidbody> ();

		yield return null;

		spoon.GetComponent<Spoon> ().Release ();
	}


	public void Restart()
	{
		spoon.GetComponent<Spoon> ().Restart ();
	}

	public void ReRelease()
	{
		spoon.GetComponent<Spoon> ().Release ();
	}
}
