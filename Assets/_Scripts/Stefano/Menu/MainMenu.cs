using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour 
{

	public GameObject firstButton;
	public EventSystem eSystem;

	void Awake()
	{

		ChangeFirstSelected (firstButton, CheckJoystick ());

	}

	/// <summary>
	/// Controllo se è inserito un Joystick
	/// </summary>
	public bool CheckJoystick()
	{

		if (Input.GetJoystickNames().Length <= 0) 
		{

			Debug.Log ("Nessun controller inserito");

			return false;

		} 
		else 
		{

			Debug.Log ("Controller inserito");

			return true;


		}

	}

	public void ChangeFirstSelected(GameObject button, bool isGamepad)
	{

		if (isGamepad == true)
			eSystem.firstSelectedGameObject = button;
		else
			eSystem.firstSelectedGameObject = null;

	}

	/// <summary>
	/// Metodo per uscire dal gioco
	/// </summary>
	public void Exit()
	{

		Application.Quit ();

	}

	//Metodo per caricare i dati
	public void Load()
	{

		//Metodo

	}



}
