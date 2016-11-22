using System;
using UnityEngine;
using UnityEngine.Networking;

public class ConnectionManager : NetworkManager {

	private RobotManager _robotManager;
	private GameObject _robotPrefab;

	void Start() {
		
		Debug.Log("Starting Network Manager");

		// Get the robot manager component
		_robotManager = GetComponent<RobotManager>();

		// If we sucessfully connected the manager
		if(_robotManager != null) {
			Debug.Log("Robot manager loaded successfully");
		} else {
			Debug.Log("Failed loading robot manager");
		}

		// Load prefabs
		_robotPrefab = Resources.Load("Robot") as GameObject;

		// If we sucessfully connected the robot prefab
		if(_robotPrefab != null) {

			// Register the prefab for the client
			// Redundant => ClientScene.RegisterPrefab(_robotPrefab);

			Debug.Log("Robot prefab loaded successfully");
		} else {
			Debug.Log("Failed loading robot prefab");
		}

	}

	// This hook is invoked when a server is started - including when a host is started
	public override void OnStartServer() {
		Debug.Log("Server started");

		// Do nothing – Robots are added when client connects

	}

	// Called on the server when a new client connects
	public override void OnServerConnect(NetworkConnection connection) {

		// Get ID associated with connected client
		var id = connection.connectionId;

		Debug.Log("User Connected: " + id);

	}

	// Called on the server when a client is ready
	public override void OnServerReady(NetworkConnection connection){

		// Get ID associated with connected client
		var id = connection.connectionId;

		// Add a new robot to the world using id
		GameObject robot = _robotManager.AddRobot<PlayerScript>(id);

		// Spawn robot accross the network
		NetworkServer.Spawn(robot);

		Debug.Log("User with id " + id + " is ready");

	}

	// Called on the server when a client disconnects
	public override void OnServerDisconnect(NetworkConnection connection) {

		Debug.Log("User Disconnected");

		// Get the robot associated with disconnceted client
		var id = connection.connectionId;

		_robotManager.RemoveRobot(id);

	}

	public override void OnClientConnect(NetworkConnection connection) {

		// Get ID associated with connected client
		var id = connection.connectionId;

		Debug.Log("Connected with id: " + id);

		// Register prefabs for the client to spawn
		// Redundant -> ClientScene.RegisterPrefab(_robotPrefab);

	}

	public override void OnClientDisconnect(NetworkConnection connection) {

		// Get ID associated with connected client
		//var id = connection.connectionId;

		Debug.Log("Lost connection with server");

	}
}

