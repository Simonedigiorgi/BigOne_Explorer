using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{

	public static float MainHorizontal()
	{

		float r = 0.0f;
		r += Input.GetAxis ("LeftAnalogHorizontal");
		r += Input.GetAxis ("RightAnalogHorizontal");

		return Mathf.Clamp (r, -1.0f, 1.0f); 

	}

	public static float MainVertical()
	{

		float r = 0.0f;
		r += Input.GetAxis ("LeftAnalogVertical");
		r += Input.GetAxis ("RightAnalogVertical");

		return Mathf.Clamp (r, -1.0f, 1.0f); 

  
	}

	public static Vector3 MainJoystick()
	{

		return new Vector3 (MainHorizontal (), 0, MainVertical ());

	}

	//----------- Buttons

	public static bool ABotton()
	{

		return Input.GetButtonDown ("A");

	}

	public static bool BBotton()
	{

		return Input.GetButtonDown ("B");

	}

	public static bool XBotton()
	{

		return Input.GetButtonDown ("X");

	}

	public static bool YBotton()
	{

		return Input.GetButtonDown ("Y");

	}
	
}
