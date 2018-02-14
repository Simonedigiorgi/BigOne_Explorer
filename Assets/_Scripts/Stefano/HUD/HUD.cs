using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

	#region Public 

	public Animator anim;

	#endregion 

	void Update()
	{

		//Check button start

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
	/// Metodo che ti muovi nel menu
	/// </summa
	public void MoveOnMenu(string value)
	{

		anim.Play (value);

	}

	#endregion

}
