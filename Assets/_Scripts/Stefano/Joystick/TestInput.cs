using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () 
	{

		if (InputManager.ABotton()) 
		{

			Debug.Log (InputManager.MainJoystick ());

		}
		
	}
}
