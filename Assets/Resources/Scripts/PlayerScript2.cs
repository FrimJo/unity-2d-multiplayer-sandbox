using UnityEngine;
using System.Collections;

public class PlayerScript2 : ScriptAdapter {

	private RobotController _myRobot;

	// Use this for initialization
	public override void Init(RobotController myRobot) {
		_myRobot = myRobot;
		_myRobot.transform.forward = new Vector3(1.0f, 0.0f, 0.0f);
		_myRobot.rigidbody2D.AddForce(_myRobot.transform.forward * 10.0f);
	}
	
	// Update is called once per frame
	public override void Run() {
		
	}
}
