using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadEnviroment : MonoBehaviour {

	[Header("Oggetti da salvare nella scena")]
	public List<EnviromentData> EnviromentObjects;
	private string FilePath;

	void Awake()
	{

		//Path del file di salvataggio
		FilePath = Path.Combine(Application.dataPath, "EnviromentSave.json");

		//Controllo se il file esiste
		if (File.Exists (FilePath) == false) 
		{

			//Il file non esiste allora lo creo

			Debug.Log ("Il file di salvataggio non esiste, lo creo");
			File.Create (FilePath);

		} 
		else 
		{
			//Il file di salvataggio esiste

			Debug.Log ("File salvtaggio OK");

		}

	}

	// Use this for initialization
	void Start () 
	{

		Load ();

	}

	void Update()
	{

		if (Input.GetKey (KeyCode.S)) {

			Save ();

			Debug.Log ("Salvo!");

		}

		if (Input.GetKey (KeyCode.L)) {

			Load ();

			Debug.Log ("Carico i dati");

		}

	}

	//Metodo che permette il salvataggio dei dati dell'enviroment
	void Save()
	{

		string jsonString = JsonUtility.ToJson (EnviromentObjects[0]);
		File.WriteAllText (FilePath, jsonString);

	}

	//Metodo che permette il salvataggio dei dati dell'enviroment
	void Load()
	{

		string jsonString = File.ReadAllText (FilePath);
		JsonUtility.FromJsonOverwrite (jsonString, EnviromentObjects);

	}
}
