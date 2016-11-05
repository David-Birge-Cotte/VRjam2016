using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Obstacle : MonoBehaviour {

    public float speed = 1;
    private Rigidbody _rb;

	void Start ()
    {
        _rb = GetComponent<Rigidbody>();
    }

	void Update ()
    {
        Move(-Vector3.right);
    }

    void Move(Vector3 movement)
    {
        _rb.MovePosition(transform.position + (movement * Time.deltaTime * speed));
    }

}
