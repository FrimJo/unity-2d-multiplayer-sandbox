using UnityEngine;
using System.Collections;

public class TransformProxy {

	private Transform _transform;

	public TransformProxy(Transform transform) { _transform = transform; }

	public Vector3 position {
		get { return _transform.position; }
	}

	public Vector3 forward {
		get { return _transform.forward; }
		set { _transform.forward = value; }
	}

	public Vector3 right {
		get { return _transform.right; }
		set { _transform.right = value; }
	}

	public Vector3 up {
		get { return _transform.up; }
		set { _transform.up = value; }
	}

	public Quaternion rotation {
		get { return _transform.rotation; }
		set { _transform.rotation = value; }
	}

	public void LookAt(Vector3 worldPosition){ _transform.LookAt(worldPosition); }

}
