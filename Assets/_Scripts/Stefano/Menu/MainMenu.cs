using System.Collections;
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

	#endregion

	void Awake()
	{
		
		//Controlliamo se il Joystick è stato inserito 
		ChangeFirstSelected (firstButton, CheckJoystick ());

	}

	void Update()
	{

		//Pezza
		if (timer >= 0.2f) 
		{

			timer = 0;

			if (eSystem.currentSelectedGameObject.GetHashCode () == mainMuiscButton.GetHashCode () && InputManager.MainHorizontal () < 0) {

				//Tolgo volume
				DecreaseVolume (listMainVolume, mainAudio);

			} else if (eSystem.currentSelectedGameObject.GetHashCode () == mainMuiscButton.GetHashCode () && InputManager.MainHorizontal () > 0) {
				
				//Tolgo volume
				EncreaseVolume (listMainVolume, mainAudio);

			}

			if (eSystem.currentSelectedGameObject.GetHashCode () == SFXbutton.GetHashCode () && InputManager.MainHorizontal () < 0) {

				//Tolgo volume
				DecreaseVolume (listSFXVolume, SFXaudio);

			} else if (eSystem.currentSelectedGameObject.GetHashCode () == SFXbutton.GetHashCode () && InputManager.MainHorizontal () > 0) {
				
				//Tolgo volume
				EncreaseVolume (listSFXVolume, SFXaudio);

			}

			if (eSystem.currentSelectedGameObject.GetHashCode () == musicButton.GetHashCode () && InputManager.MainHorizontal () < 0) {

				//Tolgo volume
				DecreaseVolume (listMusicVolume, musicAudio);

			} else if (eSystem.currentSelectedGameObject.GetHashCode () == musicButton.GetHashCode () && InputManager.MainHorizontal () > 0) {
				
				//Tolgo volume
				EncreaseVolume (listMusicVolume, musicAudio);

			}

		} 
		else 
		{

			timer += Time.deltaTime;

		}


		if (background.alpha == 1) 
		{

			SceneManager.LoadScene ("Cratere Gale_Prova_2");

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
	/// Changes the first selected.
	/// </summary>
	/// <param name="button">Button.</param>
	public void ChangeFirstSelected(GameObject button)
	{

		eSystem.firstSelectedGameObject = button;

	}

	#endregion

	#region Generic

	/// <summary>
	/// Metodo per uscire dal gioco
	/// </summary>
	public void Exit()
	{

		Application.Quit ();

	}

	#endregion

}
