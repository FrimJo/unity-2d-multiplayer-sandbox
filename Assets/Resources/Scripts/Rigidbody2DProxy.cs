using UnityEngine;
using System.Collections;

public class Rigidbody2DProxy { 

	private Rigidbody2D _rigidbody2D;

	public Rigidbody2DProxy(Rigidbody2D rigidbody2D) { _rigidbody2D = rigidbody2D; }

	public void AddForce(Vector2 force) { _rigidbody2D.AddForce(force); }
	public void AddForceAtPosition(Vector2 force, Vector2 position) { _rigidbody2D.AddForceAtPosition(force, position); }
	public float rotation {
		get { return _rigidbody2D.rotation; }
		set { _rigidbody2D.rotation = value; }
	}
}
