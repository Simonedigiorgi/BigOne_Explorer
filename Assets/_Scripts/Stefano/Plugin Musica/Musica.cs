using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour {

	#region Public
	public List<Brano> PlayList;
	[Header("Audio source per l'output")]
	public AudioSource Output;
	[Header("Debug mode")]
	public bool DebugMode;
	#endregion

	#region Private
	private int ID_suono;
	#endregion

	[System.Serializable]
	public class Brano
	{
		[Header("Suono da istanziare")]
		public AudioClip Audio;
		[Header("ID univoco della canzone numerico crescente")]
		public int ID;
		[Header("Descrizione del suono")]
		public string Descrizione;
		[Header("Volume del suono")]
		[Range(0f,1f)]
		public float Volume;

	}


	/// <summary>
	/// Metodo che riproduce l'audio passando l'ID della canzone della lista
	/// </summary>
	/// <param name="ID">ID della canzone da riprodurre</param>
	public void RiproduciSuono(int ID)
	{

		if (Output.isActiveAndEnabled == true) 
		{

			for (int i = 0; i < PlayList.Count; i++) {

				if (PlayList [i].ID == ID) {

					if (DebugMode == true)
						Debug.Log ("Riproduco suono " + PlayList [i].ID);

					Output.PlayOneShot (PlayList [i].Audio, PlayList [i].Volume);
					return;

				}

			}
		} 
		else 
		{

			Debug.Log ("Errore nell'Audio Source");

		}

		Debug.LogError ("Muisca non trovata CONTROLLARE LISTA");


	}
}
