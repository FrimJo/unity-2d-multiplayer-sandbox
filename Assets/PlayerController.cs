using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public float angularDapening;
	public float linearDapening;
	public float linearSpeed;

	private float _linearSpeed = 0.0f;
	private Vector3 _moveToPosition;
	private Vector3 _lookAtPosition;
	private bool _hasMoveToTarget = false;
	private bool _hasLookAtTarget = false;

	private Robot _robot;

	private PlayerScript _script;
	private GameObject _bulletPrefab;

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

	public class Robot {

		public TransformProxy transform;
		public Rigidbody2DProxy rigidbody2D;

		public Robot(TransformProxy transform, Rigidbody2DProxy rigidbody2D) {
			this.transform = transform;
			this.rigidbody2D = rigidbody2D;
		}
	}

	// Use this for initialization
	void Start () {

		// Get the rigidbody
		var body = GetComponent<Rigidbody2D>();
		//body.AddForce(new Vector2(10.0f, 10.0f));

		// Create a rigidbody2d proxy and add it to the controller
		var rigidbody2D = new Rigidbody2DProxy(body);

		// Create a transform proxy and add it to the controller
		var transform = new TransformProxy(this.transform);

		// Create the robot
		_robot = new Robot(transform, rigidbody2D);

		// Load the prefab for the bullet
		//_bulletPrefab = Resources.Load("Bullet") as GameObject;

		// Get the player script
		_script = GetComponent<PlayerScript>();

		// Load up player script
		//_script.Init(_robot);
	}
	
	// Update is called once per frame
	void Update () {
		
		// Run script
		//_script.Run();

		/*// If we have a target
		if(_hasMoveToTarget) {
			transform.position = Vector3.MoveTowards(transform.position, _moveToPosition, linearSpeed * Time.deltaTime);

			// If we have same posiiton as target we have arrived
			if(transform.position == _moveToPosition) _hasMoveToTarget = false;
		}

		if(_hasLookAtTarget) {
			transform.LookAt(_lookAtPosition);
		}*/
	}
		
	public void fire() {

		// Create a bullet object
		GameObject bullet = Instantiate(_bulletPrefab) as GameObject;
		bullet.transform.position = transform.position + transform.forward/2.0f;
		bullet.transform.forward = transform.forward;

		var bulletScript = bullet.GetComponent<BulletMove>();
		bulletScript.fire();

	}

	public void setAngularSpeed(float angularSpeed) {
		//_body.angularVelocity = angularSpeed;
	}

	public void setLinearSpeed(float linearSpeed) {
		_linearSpeed = linearSpeed;
	}

	public void moveTo(Transform player) {
		this.moveTo(player.position);
	}

	public void moveTo(Vector3 position) {
		_moveToPosition = position;
		_hasMoveToTarget = true;
	}

	public void lookAt(Transform player) {

		this.lookAt(player.position);
	}

	public void lookAt(Vector3 position) {

		_lookAtPosition = position;

		// Dampened or not?
		//var rotation = Quaternion.LookRotation(position - transform.position);
		//transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * angularDapening);
		_hasLookAtTarget = true;
	}

	public void moveToCover() {
		
	}

	public Transform[] getAllPlayers() {

		// Get all players

		// Return a list of players
		return new Transform[0];
	}

	public Transform[] getAllBullets() {

		// Get all bullets

		// Return a list of bullets
		return new Transform[0];
	}

	public Vector3[] getArenaCorners() {
		return new Vector3[] {
			new Vector3(0.0f,0.0f,0.0f),
			new Vector3(13.0f,0.0f,0.0f),
			new Vector3(13.0f,10.0f,0.0f),
			new Vector3(0.0f,10.0f,0.0f)
		};
	}

}
