using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script che gestisce il gadget della fotocamera
/// </summary>
public class Fotocamera : MonoBehaviour 
{

	#region Public 

	[Range(0, 10)]
	public float velocity;
	public CanvasGroup flash;
	public bool isActive;

	public GameObject ogg;
	public GameObject buttonFlash;

	#endregion

	#region Private 

	private bool exit;
	private bool temp = false;
	private Camera camPhoto;

	#endregion 

	void Update()
	{
		
		if (isActive == true) 
		{

			//Scatto la foto
			FlashTemp ();
			//Controllo se ho il target di un oggetto
			TakeTargetPhoto ();

		}
			

	}

	/// <summary>
	/// Changes the camera.
	/// </summary>
	/// <param name="cam">Cam. da attivare</param>
	public void ChangeCamera(Camera cam)
	{

		Camera.main.enabled = false;
		cam.enabled = true;
		camPhoto = cam;
		isActive = true;

	}
		
	/// <summary>
	/// Changes the camera to main.
	/// </summary>
	/// <param name="cam">Cam. da disattivare</param>
	public void ChangeCameraToMain(Camera cam)
	{

		Camera.main.enabled = true;
		cam.enabled = false;

	}
		
	/// <summary>
	/// Metodo che scatta una foto	
	/// </summary>
	public void TakePhoto()
	{

		exit = false;
		temp = true;
		//StartCoroutine (Flash());


	}

	/// <summary>
	/// Metodo che controlla se stai puntando al target corretto
	/// </summary>
	public void TakeTargetPhoto()
	{

		Plane[] planes = GeometryUtility.CalculateFrustumPlanes (camPhoto);

		if (GeometryUtility.TestPlanesAABB (planes, ogg.GetComponent<Renderer> ().bounds)) 
		{

			Debug.Log ("Yeah");
			buttonFlash.SetActive (true);

		} 
		else 
		{

			buttonFlash.SetActive (false);

		}

	}

	/// <summary>
	/// Metodo temporaneo che si occupa di avviare il flash
	/// </summary>
	public void FlashTemp()
	{

		if (temp == true) 
		{

			if (flash.alpha < 1 && exit == false) 
			{

				flash.alpha += Time.deltaTime * velocity;

			}

			if (flash.alpha == 1) 
			{

				exit = true;

			}

			if (flash.alpha >= 0 && exit == true)
			{

				flash.alpha -= Time.deltaTime * velocity;

			}

			if (flash.alpha <= 0.01) 
			{
				flash.alpha = 0;
				temp = false;
				ogg.SetActive (false);

			}

		}

	}

	/// <summary>
	/// Coroutine che esegue il flash 
	/// </summary>
	private IEnumerator Flash()
	{

		bool exit = false;

		do 
		{

			Debug.Log(flash.alpha);

			if (flash.alpha < 1 && exit == false) 
			{

				flash.alpha += Time.deltaTime * velocity;

			}

			if (flash.alpha == 1) 
			{

				exit = true;

			}

			if (flash.alpha >= 0 && exit == true)
			{

				flash.alpha -= Time.deltaTime * velocity;

			}

			if (flash.alpha <= 0.01) 
			{
				flash.alpha = 0;
				yield return null;

			}


		} while(true);

	}


}
