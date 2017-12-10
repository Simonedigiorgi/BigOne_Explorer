using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour {

	#region Public 
	public GameObject O2controller;
	public GameObject CompassController;
	#endregion

	#region Private 
	private Ossigeno O2;
	private CompassLocation compass;
	#endregion

	void Awake()
	{

		O2 = O2controller.GetComponent<Ossigeno> ();
		compass = CompassController.GetComponent<CompassLocation>();

	}
	
	// Update is called once per frame
	private void Update () 
	{

		if (InputManager.UPArrow ()) 
		{

			Debug.Log ("Disabilito l'ossigeno");
			compass.DisableCompass ();

		}
		
	}
}
