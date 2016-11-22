using System;
using UnityEngine;
using UnityEngine.Networking;

public abstract class ScriptAdapter : NetworkBehaviour, IScript {
	
	// Use this for initialization
	public abstract void Init(RobotController myRobot);

	// Update is called once per frame
	public abstract void Run();
}

