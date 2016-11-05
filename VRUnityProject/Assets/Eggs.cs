using UnityEngine;
using System.Collections;

public class Eggs : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.layer == 10) 
		{
			//Debug.Log ("hit spoon " + coll.relativeVelocity.magnitude);

			if (coll.relativeVelocity.magnitude > 1) {
				var device = SteamVR_Controller.Input((int)SteamVR_TrackedObject.EIndex.Device3);
				//device.TriggerHapticPulse (500, Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
			}
		}
	}
}
