using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HUD : MonoBehaviour {

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

	#endregion


	void Update()
	{

		if (InputManager.StartButton () == true && player.GetComponent<Invector.CharacterController.vThirdPersonController> ().isGrounded == true && semaforo == true) 
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

		//Pezza
		if (timer >= 0.2f && semaforo == false) 
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

}
