using UnityEngine;
using System.Collections;

public class Eggs : MonoBehaviour {

    private AudioClip Break;
    private AudioClip Fries;
	public MeshCollider meshCollider = null; 

	public int index;

	// Use this for initialization
	void Start ()
    {
        Break = Resources.Load<AudioClip>("FX/SND_Egg_Breaks");
        Fries = Resources.Load<AudioClip>("FX/SND_Egg_Fries");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.layer == 9) 
		{
			//var device = SteamVR_Controller.Input((int)SteamVR_TrackedObject.EIndex.Device3);
			//device.TriggerHapticPulse (500, Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);			

            Camera.main.GetComponent<AudioSource>().PlayOneShot(Break);

			GameObject.FindObjectOfType<GameOver> ().LooseEgg (index);
        }

		if (coll.gameObject.layer == 11) 
		{
			GameObject.FindObjectOfType<GameOver> ().LooseEgg (index);
			SetLayer (9);
			Camera.main.GetComponent<AudioSource>().PlayOneShot(Fries);
		}
	}

	public void SetLayer (int layer)
	{
		gameObject.layer = layer;
		meshCollider.gameObject.layer = layer;
	}
}
