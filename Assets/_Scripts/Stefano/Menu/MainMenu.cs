using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour 
{

	public GameObject firstButton;
	public EventSystem eSystem;
	public Animator anim;
	public Animator mainMenu;

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

	public void PlayAnimationCamera(string value)
	{

		anim.Play(value);

	}

	public void PlayAnimationMainMenu(string value)
	{

		mainMenu.Play (value);

	}

	/// <summary>
	/// Cambiare il first select dell'Event System
	/// </summary>
	/// <param name="button">Button.</param>
	/// <param name="isGamepad">If set to <c>true</c> is gamepad.</param>
	public void ChangeFirstSelected(GameObject button, bool isGamepad)
	{

		if (isGamepad == true)
			eSystem.firstSelectedGameObject = button;
		else
			eSystem.firstSelectedGameObject = null;

	}

	/// <summary>
	/// Changes the first selected.
	/// </summary>
	/// <param name="button">Button.</param>
	public void ChangeFirstSelected(GameObject button)
	{

		eSystem.firstSelectedGameObject = button;

	}

	/// <summary>
	/// Metodo per uscire dal gioco
	/// </summary>
	public void Exit()
	{

		Application.Quit ();

	}

	/// <summary>
	/// Caricare i dati 
	/// </summary>
	public void Load()
	{

		//Metodo

	}



}
