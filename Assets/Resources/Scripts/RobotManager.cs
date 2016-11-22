using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.Networking;


public class RobotManager : MonoBehaviour {

	private Dictionary<int, IScript> _robotScriptDictionary = new Dictionary<int, IScript>();
	private Dictionary<int, GameObject> _robotDictionary = new Dictionary<int, GameObject>();
	private GameObject _robotPrefab;

	private bool _isReady = false;

	public bool isReady {
		get { return _isReady; }
		set {_isReady = value; }
	}
		
	void Start() {

		// Get the robot prefab
		_robotPrefab = Resources.Load("Robot") as GameObject;

		// Tell the world that the manager is ready to add scripts
		isReady = true;
	}

	public GameObject AddRobot<T>(int id) where T : IScript {
		
		// Get robot script and addd it to container
		//IScript script = gameObject.AddComponent<PlayerScript>();

		// If script exists
		//if (script != null) {

			// Create robot with start position and rotaiton
			GameObject robot = (GameObject)Instantiate(_robotPrefab, Vector3.zero, Quaternion.identity);

			// Add the script to the robot
			IScript script = robot.AddComponent<PlayerScript>();

			// Add the robot to list of robots
			_robotDictionary.Add(id, robot);

			// Create a controller for the robot
			RobotController robotController = new RobotController(robot);

			/* Order is important! */

			// 1. Init script with controller
			script.Init(robotController);

			// 2. Add the script to list of scripts
			_robotScriptDictionary.Add(id, script);

			return robot;

		//} else {
			
		//	throw new Exception("Could not load add script");
		//}

	}

	public void RemoveRobot(int id){

		Debug.Log("Removeing robot with id: " + id + " out of " + _robotDictionary.Count);

		// Remove the script from dictionary
		_robotScriptDictionary.Remove(id);

		// Container for robot
		GameObject robot;

		// Get robot to remove
		_robotDictionary.TryGetValue(id, out robot);

		// If the robot exists
		if(robot != null) {
			
			// Remove the robot for the dicitonary
			_robotDictionary.Remove(id);

			// Remove robot from the network
			NetworkServer.UnSpawn(robot);

			// Removes the robot from the world
			Destroy(robot);

			Debug.Log("Robot removed");

		} else {

			Debug.Log("Could not find robot");
		}



	}

	void FixedUpdate() {

		// Run the run method for all robot scripts
		foreach( IScript script in _robotScriptDictionary.Values ) {
			script.Run();	
		}

	}

}


