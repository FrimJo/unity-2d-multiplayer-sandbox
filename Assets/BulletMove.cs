using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {}

	public void fire(){
		GetComponent<Rigidbody2D>().velocity = transform.forward * speed;
	}
}
