using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HUD : MonoBehaviour {

	#region Public 

	public Animator anim;
	public GameObject eSystem;
	public GameObject player;
	public GameObject firstButton;

	#endregion 

	#region Private

	private bool semaforo = true;

	#endregion


	void Update()
	{

		if (InputManager.StartButton () == true && player.GetComponent<Invector.CharacterController.vThirdPersonController> ().isGrounded == true && semaforo == true) 
		{

			semaforo = false;
			eSystem.SetActive (true);
			OpenMenu ();
			player.GetComponent<Invector.CharacterController.vThirdPersonInput> ().enabled = false;

		} 
		else if (semaforo == false && InputManager.StartButton () == true) 
		{

			semaforo = true;
			CloseMenu ();
			player.GetComponent<Invector.CharacterController.vThirdPersonInput> ().enabled = true;
			eSystem.SetActive (false);

		}

	}

	#region Animazioni

	/// <summary>
	/// OMetodo che apre il menu
	/// </summary>
	public void OpenMenu()
	{

		anim.Play("Move");

	}

	/// <summary>
	/// Metodo che chiude il menu	
	/// </summary>
	public void CloseMenu()
	{

		anim.Play ("MoveReturn");

	}

	/// <summary>
	/// Metodo che ti muovi nel menu
	/// </summa
	public void MoveOnMenu(string value)
	{

		anim.Play (value);

	}

	#endregion

	#region Manager

	public void ResumeGame()
	{

		CloseMenu ();
		player.GetComponent<Invector.CharacterController.vThirdPersonInput> ().enabled = true;
		eSystem.GetComponent<EventSystem> ().SetSelectedGameObject (firstButton);
		eSystem.SetActive (false);

	}

	#endregion

}
