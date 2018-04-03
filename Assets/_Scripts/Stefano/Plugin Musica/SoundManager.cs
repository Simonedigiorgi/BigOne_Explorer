using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

	public Musica2 music;
	public static bool isRadio = false;
	private int nStation = 0;

	public int Scena0;
	public int Scena1;
	public int Scena2;
	public int Scena3;
	public int Scena4;

	public AudioMixer mixerMusic;

	[Header("Variabile da utilizzare in case di Debug, togliere in delivery")]
	public bool isDebug = false;

	void Start()
	{

		if (isDebug == true) 
		{

			PlayerPrefs.SetInt ("isFirstTime", 0);

		}

		Debug.Log (gameObject.name);

		Scene currentScena = SceneManager.GetActiveScene ();


		if (currentScena.buildIndex == Scena0) 
		{

			//Vento
			music.GoStartMusic (0,0);

		}

		if (currentScena.buildIndex == Scena1)
		{

			//Controlliamo se è una nuova partita
			if (PlayerPrefs.GetInt ("isFirstTime") == 0)
			{

				PlayerPrefs.SetInt ("isFirstTime", 1);
				music.GoSnapShotFade (0);

			} 
			else 
			{

				music.GoSnapShotFade (1);

			}

			//music.GoStartMusic (0, 0);
			//music.GoStartMusic (0, 1);
			//Vento
			//music.GoStartMusic (0, 2);
			//music.GoStartMusic (0, 3);
			//music.GoStartMusic (0, 4);
			//music.GoStartMusic (0, 5);

		}

		if (currentScena.buildIndex == Scena2) 
		{

			//Vento
			music.GoStartMusic (0, 2);
			music.GoSnapShotFade (1);

		}

		if (currentScena.buildIndex == Scena3) 
		{

			//Vento
			music.GoStartMusic (0, 2);
			music.GoSnapShotFade (1);

		}

		if (currentScena.buildIndex == Scena4) 
		{

			//Vento
			music.GoStartMusic (0, 2);
			music.GoSnapShotFade (1);

		}


		if (currentScena.buildIndex != Scena0)
		{
			//Eseguiamo la radio
			mixerMusic.SetFloat ("Volume", -80f);
			music.GoRandomClusterFade (0);
		}

	}

	void Update()
	{

		//Ovattato
		if (Input.GetKeyDown (KeyCode.O)) 
		{

			music.GoSnapShotFade (1);

		}

		//Non ovattato
		if (Input.GetKeyDown (KeyCode.P)) 
		{

			music.GoSnapShotFade (2);

		}


		if ((Input.GetKeyDown (KeyCode.U) || InputManager.UPArrow() )&& SceneManager.GetActiveScene().buildIndex != Scena0 ) 
		{

			SetRadio ();

		}

		if (Input.GetKeyDown (KeyCode.P)) 
		{

			music.GoChangeMusicClusterFade (0);

		}
			

	}

	#region Radio

	/// <summary>
	/// Metodo che si occupa di attivare o disattivare la radio 
	/// </summary>
	private void SetRadio ()
	{

		music.GoPlayOneShot (2);

		if (isRadio == false) 
		{

			isRadio = true;
			mixerMusic.SetFloat("Volume", ES2.Load<float> ("Setting.txt?tag="+mixerMusic.name));

			Debug.Log ("Radio attiva");

		} 
		else 
		{

			isRadio = false;
			mixerMusic.SetFloat("Volume", -80f);

			Debug.Log ("Radio disattiva");

		}

	}

	#endregion

}
