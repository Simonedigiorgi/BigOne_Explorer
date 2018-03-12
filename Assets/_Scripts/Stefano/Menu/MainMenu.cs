﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{

	#region Public 

	public CanvasGroup background;

	public GameObject firstButton;
	public EventSystem eSystem;
	public Animator anim;
	public Animator mainMenu;
	public Animator doorUp;
	public Animator doorDown;

	[Header("Marker per alzare o diminuire i volumi")]
	public GameObject mainMuiscButton;
	public GameObject SFXbutton;
	public GameObject musicButton;

	public Color32 disableColor;
	public Color32 enableColor;

	[Header("Lista MAIN VOLUME")]
	public List<Image> listMainVolume;
	public AudioSource mainAudio;
	[Header("Lista SFX VOLUME")]
	public List<Image> listSFXVolume;
	public AudioSource SFXaudio;
	[Header("Lista MUSIC VOLUME")]
	public List<Image> listMusicVolume;
	public AudioSource musicAudio;


	#endregion 

	#region Private 

	//Pezza
	private float timer = 0.2f;
	private GameObject tempESystem;
	private GameObject Player;
	private bool isGamepad = false;

	#endregion

	void Awake()
	{

		//Impostiamo il primo bottone illuminato 
		ChangeFirstSelected (firstButton);

		Player = GameObject.FindGameObjectWithTag ("Player");

		if (Player != null) 
		{

			Player.SetActive (false);

		}

		tempESystem = eSystem.firstSelectedGameObject;

		//Avvio la coroutine per il controllo degli input
		StartCoroutine (CheckInput ());


	}

	void Update()
	{

		if (isGamepad == true) 
		{

			#region SettingAudio

			//Controllo audio per il menu principale 
			if (timer >= 0.2f) {

				timer = 0;

				#region MainAudio

				if (eSystem.currentSelectedGameObject.GetHashCode () == mainMuiscButton.GetHashCode () && InputManager.MainHorizontal () < 0) {

					//Tolgo volume
					DecreaseVolume (listMainVolume, mainAudio);
					this.GetComponent<Musica> ().RiproduciSuono (4);

				} else if (eSystem.currentSelectedGameObject.GetHashCode () == mainMuiscButton.GetHashCode () && InputManager.MainHorizontal () > 0) {
					
					//Tolgo volume
					EncreaseVolume (listMainVolume, mainAudio);
					this.GetComponent<Musica> ().RiproduciSuono (4);

				}

				#endregion

				#region SFXaudio

				if (eSystem.currentSelectedGameObject.GetHashCode () == SFXbutton.GetHashCode () && InputManager.MainHorizontal () < 0) {

					//Tolgo volume
					DecreaseVolume (listSFXVolume, SFXaudio);
					this.GetComponent<Musica> ().RiproduciSuono (4);

				} else if (eSystem.currentSelectedGameObject.GetHashCode () == SFXbutton.GetHashCode () && InputManager.MainHorizontal () > 0) {
					
					//Tolgo volume
					EncreaseVolume (listSFXVolume, SFXaudio);
					this.GetComponent<Musica> ().RiproduciSuono (4);

				}

				#endregion

				#region MusicAudio

				if (eSystem.currentSelectedGameObject.GetHashCode () == musicButton.GetHashCode () && InputManager.MainHorizontal () < 0) {

					//Tolgo volume
					DecreaseVolume (listMusicVolume, musicAudio);
					this.GetComponent<Musica> ().RiproduciSuono (4);

				} else if (eSystem.currentSelectedGameObject.GetHashCode () == musicButton.GetHashCode () && InputManager.MainHorizontal () > 0) {
					
					//Tolgo volume
					EncreaseVolume (listMusicVolume, musicAudio);
					this.GetComponent<Musica> ().RiproduciSuono (4);

				}

				#endregion

			} else {

				timer += Time.deltaTime;

			}

			#endregion

		}

		if (isGamepad == true) 
		{

			#region MusicOnMenu

			if (eSystem.currentSelectedGameObject.GetHashCode () != tempESystem.GetHashCode () && InputManager.MainVertical () != 0) {

				tempESystem = eSystem.currentSelectedGameObject;
				this.GetComponent<Musica> ().RiproduciSuono (1);

			}

			#endregion

		}

	}

	#region Volume

	/// <summary>
	/// Metodo che aumenta il volume del gioco
	/// </summary>
	public void EncreaseVolume( List<Image> list, AudioSource audio)
	{

		for (int i = 0; i < list.Count; i++) 
		{

			if (list [i].color == disableColor) 
			{

				audio.volume += 0.1f;
				list [i].color = enableColor;
				return;

			}

		}

	}

	/// <summary>
	/// Metodo che diminuisce il volume di gioco
	/// </summary>
	public void DecreaseVolume( List<Image> list, AudioSource audio)
	{

		for (int i = 1; i <= list.Count; i++) 
		{

			if (list [list.Count-i].color == enableColor) 
			{

				audio.volume -= 0.1f;
				list [list.Count-i].color = disableColor;
				return;

			}

		}

	}

	#endregion

	#region Joystick

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

			//Disabilitiamo gli input da Mouse
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;



			return true;


		}

	}

	#endregion

	#region Animazioni

	/// <summary>
	/// Metodo che gestisce l'animator della main camera
	/// </summary>
	/// <param name="value">Value.</param>
	public void PlayAnimationCamera(string value)
	{

		anim.Play(value);

	}

	/// <summary>
	/// Metodo che permette di gestire l'animator del main menu
	/// </summary>
	/// <param name="value">Value.</param>
	public void PlayAnimationMainMenu(string value)
	{

		mainMenu.Play (value);

	}

	/// <summary>
	/// Metodo che attiva il movimento della porta
	/// </summary>
	public void PlayAnimationDoorUp()
	{

		doorUp.Play ("LeftDoor");

	}

	/// <summary>
	/// Metodo che attiva il movimento della porta
	/// </summary>
	public void PlayAnimationDoorDown()
	{

		doorDown.Play ("RightOpen");

	}

	#endregion

	#region EventSystem

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
	/// Cambiare il first select dell'Event System
	/// </summary>
	/// <param name="button">Button.</param>
	public void ChangeFirstSelected(GameObject button)
	{

		eSystem.firstSelectedGameObject = button;

	}

	#endregion

	#region MenuFunction

	/// <summary>
	/// Metodo per uscire dal gioco
	/// </summary>
	public void Exit()
	{

		Application.Quit ();

	}

	/// <summary>
	/// Metodo che avvia la coroutine per cambiare scena
	/// </summary>
	/// <param name="nameScena">Name scena.</param>
	public void ChangeScena(string nameScena)
	{

		StartCoroutine (FadeScena (nameScena));

	}

	/// <summary>
	/// Metodo che avvia la coroutine per cambiare scena
	/// </summary>
	/// <param name="nameScena">Name scena.</param>
	public void ChangeScena(int index)
	{
		//Converto il numero di scena in nome
		string nameScena = SceneManager.GetSceneByBuildIndex (index).name;

		StartCoroutine (FadeScena (nameScena));

	}

	/// <summary>
	/// Coroutine che controlla il cambio di scena 
	/// </summary>
	/// <returns>The scena.</returns>
	public IEnumerator FadeScena(string nameScena)
	{

		while(background.alpha < 1)
		{

			//Aseptto che lo schermo sia totalmente nero

			yield return null;


		}

		if (Player != null) 
		{

			Player.SetActive (true);

		}

		SceneManager.LoadScene (nameScena);


	}

	/// <summary>
	/// Coroutine che controlla il cambio di input del gioco
	/// </summary>
	/// <returns>The input.</returns>
	public IEnumerator CheckInput()
	{

		while (true) 
		{

			//Controllo ogni quanto di tempo se il Joystick o la tastiera sono stati inseriti
			isGamepad = CheckJoystick ();

			yield return new WaitForSeconds (1f);

		}

		yield return null;


	}

	#endregion

}
