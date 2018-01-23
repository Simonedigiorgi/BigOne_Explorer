using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

/// <summary>
/// Script che setta il valore 
/// </summary>
public class ManageSaveFile : MonoBehaviour 
{

	#region Public 

	[Header("Scena da caricare in caso di New Game")]
	public string firstScene;
	[Header("Pannello dan avviare in caso di cancellazione dati di gioco")]
	public GameObject panelChoise;

	#endregion

	#region Private 

	private string newGame;

	#endregion

	/// <summary>
	/// Settiamo il fileda cui caricheremo e salveremo i dati in questa partitia
	/// </summary>
	/// <param name="value">Value.</param>
	public void SetSlot(string value)
	{

		PlayerPrefs.SetString ("Slot", value);

	}

	/// <summary>
	/// Puliamo uno slot e lo reinizializiamo
	/// </summary>
	/// <param name="value">Value.</param>
	public void RefreshFile()
	{
		 
		ES2.Delete ( newGame + ".txt");
		SceneManager.LoadScene (firstScene);

	}

	/// <summary>
	/// Settiamo il nome del file che andremo a distruggere per poi ricrearlo
	/// </summary>
	/// <param name="value">Value.</param>
	public void SetNewGame(string value)
	{

		newGame = value;

		SetSlot (value);

		if (ES2.Exists (newGame + ".txt"))
			panelChoise.SetActive (true);
		else
			SceneManager.LoadScene (firstScene);

	}

}
