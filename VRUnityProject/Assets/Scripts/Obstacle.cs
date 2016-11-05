using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Obstacle : MonoBehaviour {

    public float speed = 1;
    private Rigidbody _rb;

    private float life;

	void Start ()
    {
        _rb = GetComponent<Rigidbody>();
        life = 0;
    }

	void Update ()
    {
        Move(-Vector3.right);
        life += Time.deltaTime;

        if(life > 20)
        {
            Destroy(this.gameObject);
        }
    }

    void Move(Vector3 movement)
    {
        _rb.MovePosition(transform.position + (movement * Time.deltaTime * speed));
    }

}
