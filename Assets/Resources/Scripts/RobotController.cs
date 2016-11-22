using UnityEngine;
using System.Collections;

public class RobotController {

	private TransformProxy _transform;
	private Rigidbody2DProxy _rigidbody2D;

	public TransformProxy transform {
		get { return _transform; }
		set { _transform = value; }
	}

	public Rigidbody2DProxy rigidbody2D {
		get { return _rigidbody2D; }
		set { _rigidbody2D = value; }
	}

	public RobotController(GameObject robot) {

		// Create proxy transform from the player object
		_transform = new TransformProxy(robot.transform);

		// Create proxy rigidbody2D from the player object
		_rigidbody2D = new Rigidbody2DProxy(robot.GetComponent<Rigidbody2D>());

	}
}

