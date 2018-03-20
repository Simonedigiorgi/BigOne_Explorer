using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class HUD : MonoBehaviour {

	#region Public 

	[Space(10)]
	public ScreenMenu[] menu;

	[Space(10)]
	public EventSystem eSystem;
	public Animator animPauseMenu;

	[Header("Marker per alzare o diminuire i volumi")]
	public GameObject mainMusicButton;
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

	[Header("Oggetto che contiene questo menu")]
	public GameObject pauseMenu;

	#endregion 

	[Serializable]
	public class ScreenMenu
	{

		[Header("Schermata")]
		[Space(5)]

		public GameObject screen;
		public GameObject buttonSelect;
		public bool isActive;

	}

	#region Private 

	private float timer = 0.2f;
	private GameObject Player;
	private bool isGamepad = false;
	private bool checkIsGamepad = false;
	private bool menuIsOpen = false;

	#endregion

	void Start()
	{

		//Impostiamo il primo bottone illuminato 
		ChangeFirstSelected (CheckJoystick());

		checkIsGamepad = isGamepad;

		/*Player = GameObject.FindGameObjectWithTag ("Player");

		if (Player != null) 
		{

			Player.SetActive (false);

		}*/

		//tempESystem = eSystem.firstSelectedGameObject;

		//Avvio la coroutine per il controllo degli input
		StartCoroutine (CheckInput ());


	}

	void Update()
	{

		//Se il tasto start viene premeuto avviamo il menu 
		if (InputManager.StartButton () == true && menuIsOpen == false) 
		{
			
			MoveOnMenu ("PasueMenu_new");
			menuIsOpen = true;
            vThirdPersonController.instance.GetComponent<GenericSettings>().LockPlayer();

		}

		if (isGamepad == true && menuIsOpen == true) 
		{

			#region SettingAudio

			//Controllo audio per il menu principale 
			if (timer >= 0.08f && isGamepad == true && eSystem.currentSelectedGameObject != null) 
			{

				timer = 0;

				#region MainAudio

				if (eSystem.currentSelectedGameObject.GetHashCode () == mainMusicButton.GetHashCode () && InputManager.MainHorizontal () < -0.5) {

					//Tolgo volume
					DecreaseVolume (listMainVolume, mainAudio);
					//this.GetComponent<Musica> ().RiproduciSuono (4);

				} else if (eSystem.currentSelectedGameObject.GetHashCode () == mainMusicButton.GetHashCode () && InputManager.MainHorizontal () > 0.5) {

					//Tolgo volume
					EncreaseVolume (listMainVolume, mainAudio);
					//this.GetComponent<Musica> ().RiproduciSuono (4);

				}

				#endregion

				#region SFXaudio

				if (eSystem.currentSelectedGameObject.GetHashCode () == SFXbutton.GetHashCode () && InputManager.MainHorizontal () < -0.5) {

					//Tolgo volume
					DecreaseVolume (listSFXVolume, SFXaudio);
					//this.GetComponent<Musica> ().RiproduciSuono (4);

				} else if (eSystem.currentSelectedGameObject.GetHashCode () == SFXbutton.GetHashCode () && InputManager.MainHorizontal () > 0.5) {

					//Tolgo volume
					EncreaseVolume (listSFXVolume, SFXaudio);
					//this.GetComponent<Musica> ().RiproduciSuono (4);

				}

				#endregion

				#region MusicAudio

				if (eSystem.currentSelectedGameObject.GetHashCode () == musicButton.GetHashCode () && InputManager.MainHorizontal () < -0.5) {

					//Tolgo volume
					DecreaseVolume (listMusicVolume, musicAudio);
					//this.GetComponent<Musica> ().RiproduciSuono (4);

				} else if (eSystem.currentSelectedGameObject.GetHashCode () == musicButton.GetHashCode () && InputManager.MainHorizontal () > 0.5) {

					//Tolgo volume
					EncreaseVolume (listMusicVolume, musicAudio);
					//this.GetComponent<Musica> ().RiproduciSuono (4);

				}

				#endregion

			} else {

				timer += Time.deltaTime;

			}

			#endregion

		}

	}

	#region Volume

	/// <summary>
	/// Metodo che muta gli audio
	/// </summary>
	/// <param name="nameList">Name list.</param>
	public void Mute(string nameList)
	{

		if (nameList == "Music") 
		{

			for (int i = 0; i < listMusicVolume.Count; i++)
			{

				listMusicVolume [i].color = disableColor;

			}

			musicAudio.volume = 0;

			Debug.Log ("Music mute");

		} 
		else if (nameList == "SFX")
		{

			for (int i = 0; i < listSFXVolume.Count; i++)
			{

				listSFXVolume [i].color = disableColor;

			}

			SFXaudio.volume = 0;

			Debug.Log ("SFX mute");

		} 
		else if (nameList == "Main") 
		{

			for (int i = 0; i < listMainVolume.Count; i++) 
			{

				listMainVolume [i].color = disableColor;

			}

			mainAudio.volume = 0;

			Debug.Log("Mian mute");

		}


	}

	#region Mouse

	/// <summary>
	/// Metodo che aumenta il volume con il mouse
	/// </summary>
	/// <param name="button">Button.</param>
	public void ChangeVolumeMain(GameObject button)
	{

		string name = button.name;
		float v = 1f;

		for (int i = 0; i < listMainVolume.Count; i++) 
		{

			listMainVolume [i].color = disableColor;

			if (listMainVolume [i].name == name) 
			{

				//Ciclo che attiva i colori
				for (int j = 0; j <= i; j++) 
				{

					v += 0.1f;
					listMainVolume [j].color = enableColor;

				}

			}

			v -= 0.1f;

		}

		//Camvio effettio del volume
		mainAudio.volume = v;

	}

	/// <summary>
	/// Metodo che aumenta il volume con il mouse
	/// </summary>
	/// <param name="button">Button.</param>
	public void ChangeVolumeMusic(GameObject button)
	{

		string name = button.name;

		float v = 1f;

		for (int i = 0; i < listMusicVolume.Count; i++) 
		{

			listMusicVolume [i].color = disableColor;

			if (listMusicVolume [i].name == name) 
			{

				//Ciclo che attiva i colori
				for (int j = 0; j <= i; j++) 
				{

					v += 0.1f;
					listMusicVolume [j].color = enableColor;

				}

			}

			v -= 0.1f;

		}

		musicAudio.volume = v;

	}

	/// <summary>
	/// Metodo che aumenta il volume con il mouse
	/// </summary>
	/// <param name="button">Button.</param>
	public void ChangeVolumeSFX(GameObject button)
	{

		string name = button.name;

		float v = 1f;

		for (int i = 0; i < listSFXVolume.Count; i++) 
		{

			listSFXVolume [i].color = disableColor;

			if (listSFXVolume [i].name == name) 
			{

				//Ciclo che attiva i colori
				for (int j = 0; j <= i; j++) 
				{

					v += 0.1f;	
					listSFXVolume [j].color = enableColor;

				}

			}

			v -= 0.1f;

		}

		SFXaudio.volume = v;

	}

	#endregion

	#region Joystic

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

	#endregion

	#region Animazioni

	/// <summary>
	/// Metodo che ti muovi nel menu
	/// </summa
	public void MoveOnMenu(string value)
	{

		animPauseMenu.Play (value);

	}

	#endregion

	#region EventSystem

	/// <summary>
	/// Cambiare il first select dell'Event System
	/// </summary>
	/// <param name="button">Button.</param>
	/// <param name="isGamepad">If set to <c>true</c> is gamepad.</param>
	public void ChangeFirstSelected(bool isGamepad)
	{

		if (isGamepad == true) 
		{

			mainMusicButton.GetComponent<Button>().enabled = true;
			SFXbutton.GetComponent<Button>().enabled = true;
			musicButton.GetComponent<Button>().enabled = true;

			for (int i = 0; i < menu.Length; i++) 
			{

				if (menu [i].isActive == true) 
				{

					eSystem.firstSelectedGameObject = menu[i].buttonSelect;
					eSystem.SetSelectedGameObject (menu [i].buttonSelect);
					return;

				}

			}

		} 
		else 
		{
			
			mainMusicButton.GetComponent<Button>().enabled = false;
			SFXbutton.GetComponent<Button>().enabled = false;
			musicButton.GetComponent<Button>().enabled = false;
			eSystem.firstSelectedGameObject = null;
			eSystem.SetSelectedGameObject (null);

		}



	}

	/// <summary>
	/// Cambiare il first select dell'Event System
	/// </summary>
	/// <param name="button">Button.</param>
	public void ChangeFirstSelected(GameObject button)
	{


		if (isGamepad == true) 
		{

			for (int i = 0; i < menu.Length; i++) {

				if (menu [i].screen.activeSelf == true) {

					eSystem.firstSelectedGameObject = null;
					eSystem.SetSelectedGameObject (null);

					eSystem.firstSelectedGameObject = button;
					eSystem.SetSelectedGameObject (button);
					return;

				}

			}
		}

	}

	#endregion

	#region MenuFunction

	/// <summary>
	/// Metodo che ritorna al menu principale
	/// </summary>
	public void TurnToMainMenu()
	{

		SceneManager.LoadScene ("_UI_Menu_Stefano");

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

			if (isGamepad != checkIsGamepad) 
			{
				ChangeFirstSelected (isGamepad);
				checkIsGamepad = isGamepad;
			}

			yield return new WaitForSeconds (1f);

		}

		yield return null;


	}

	/// <summary>
	/// Controllo se è inserito un Joystick
	/// </summary>
	public bool CheckJoystick()
	{

		bool gamepad = false;

		for (int i = 0; i < Input.GetJoystickNames ().Length; i++) 
		{

			if (Input.GetJoystickNames().GetValue(i) != "") 
			{

				gamepad = true;

			}

		}

		if (gamepad == false) 
		{

			//Debug.Log ("Nessun controller inserito");
			isGamepad = false;

			//Riabilito gli input da Mouse
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;

			return false;

		} 
		else
		{

			//Debug.Log ("Controller inserito");
			isGamepad = true;

			//Disabilitiamo gli input da Mouse
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;


			return true;

		}

	}

	/// <summary>
	/// Metodo che aggiorna la scena attiva corrente nella lista menu
	/// </summary>
	/// <param name="nextScene">Next scene.</param>
	public void CurrentMenu(GameObject nextScene)
	{

		for (int i = 0; i < menu.Length; i++) 
		{

			if (menu [i].screen == nextScene) 
			{

				menu [i].isActive = true;

			} 
			else 
			{

				menu [i].isActive = false;	

			}

		}

	}

	/// <summary>
	/// Metodo che indica al sistema che il menu ora è chiuso
	/// </summary>
	public void SetCloseMenu()
	{

		menuIsOpen = false;
        vThirdPersonController.instance.GetComponent<GenericSettings>().UnlockPlayer();

	}
		
	#endregion

	#region Old

	/*

	#region Public 

	public Animator anim;
	public GameObject player;
	public GameObject firstButton;

	public EventSystem eSystem;

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

	private bool semaforo = true;
	private float timer = 0.2f;
	private GameObject tempESystem;

	#endregion


	void Awake()
	{

		tempESystem = eSystem.firstSelectedGameObject;

	}

	void Update()
	{

        if(InputManager.StartButton() == true && RoverManager.enterTrigger == false)
        {

            eSystem.SetSelectedGameObject(firstButton);


		    if (player.GetComponent<Invector.CharacterController.vThirdPersonController> ().isGrounded == true && semaforo == true && InputManager.MainHorizontal() == 0 && InputManager.MainVertical() == 0) 
		    {

			    semaforo = false;
			    eSystem.gameObject.SetActive (true);
			    OpenMenu ();
			    player.GetComponent<Invector.CharacterController.vThirdPersonInput> ().enabled = false;

		    } 
		    else if (semaforo == false && InputManager.StartButton () == true) 
		    {

			    semaforo = true;
			    CloseMenu ();
			    player.GetComponent<Invector.CharacterController.vThirdPersonInput> ().enabled = true;
			    eSystem.gameObject.SetActive (false);

		    }

        }

        //Pezza
        if (timer >= 0.2f && semaforo == false) 
		{

			timer = 0;

			if (eSystem.currentSelectedGameObject.GetHashCode () == mainMuiscButton.GetHashCode () && InputManager.MainHorizontal () < 0) {

				//Tolgo volume
				DecreaseVolume (listMainVolume, mainAudio);
				this.GetComponent<Musica> ().RiproduciSuono (4);

			} else if (eSystem.currentSelectedGameObject.GetHashCode () == mainMuiscButton.GetHashCode () && InputManager.MainHorizontal () > 0) {

				//Tolgo volume
				EncreaseVolume (listMainVolume, mainAudio);
				this.GetComponent<Musica> ().RiproduciSuono (4);

			}

			if (eSystem.currentSelectedGameObject.GetHashCode () == SFXbutton.GetHashCode () && InputManager.MainHorizontal () < 0) {

				//Tolgo volume
				DecreaseVolume (listSFXVolume, SFXaudio);
				this.GetComponent<Musica> ().RiproduciSuono (4);

			} else if (eSystem.currentSelectedGameObject.GetHashCode () == SFXbutton.GetHashCode () && InputManager.MainHorizontal () > 0) {

				//Tolgo volume
				EncreaseVolume (listSFXVolume, SFXaudio);
				this.GetComponent<Musica> ().RiproduciSuono (4);

			}

			if (eSystem.currentSelectedGameObject.GetHashCode () == musicButton.GetHashCode () && InputManager.MainHorizontal () < 0) {

				//Tolgo volume
				DecreaseVolume (listMusicVolume, musicAudio);
				this.GetComponent<Musica> ().RiproduciSuono (4);

			} else if (eSystem.currentSelectedGameObject.GetHashCode () == musicButton.GetHashCode () && InputManager.MainHorizontal () > 0) {

				//Tolgo volume
				EncreaseVolume (listMusicVolume, musicAudio);
				this.GetComponent<Musica> ().RiproduciSuono (4);

			}

		} 
		else 
		{

			timer += Time.deltaTime;

		}

		if (semaforo == false) {

			if (eSystem.currentSelectedGameObject.GetHashCode () != tempESystem.GetHashCode () && InputManager.MainVertical () != 0) {

				tempESystem = eSystem.currentSelectedGameObject;
				this.GetComponent<Musica> ().RiproduciSuono (1);

			}
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

		semaforo = true;
		CloseMenu ();
		player.GetComponent<Invector.CharacterController.vThirdPersonInput> ().enabled = true;
		eSystem.GetComponent<EventSystem> ().SetSelectedGameObject (firstButton);
		eSystem.gameObject.SetActive (false);

	}

	public void TurnToMainMenu()
	{

		SceneManager.LoadScene ("_UI_Menu_Stefano");

	}

	public void Quit()
	{

		Application.Quit ();

	}

	#endregion

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

	*/

	#endregion
	
}
