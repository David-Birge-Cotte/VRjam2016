using UnityEngine;
using System.Collections;

public class Tunnel : MonoBehaviour {

	public float speed = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (new Vector3 (0f, 0f, speed) * Time.deltaTime);
	}
}
