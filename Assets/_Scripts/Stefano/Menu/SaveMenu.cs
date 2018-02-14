using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SaveMenu : MonoBehaviour {

	#region Public 

	public List<SettingAudio> listAudio;

	#endregion

	[Serializable]
	public class SettingAudio
	{

		public AudioSource audio;
		public List<Image> listImage;

	}

	void Awake()
	{

		LoadAudio ();

	}

	public void SaveSettinngs()
	{

		SaveAudio ();

	}

	/// <summary>
	/// Metodo che salva i volumi 
	/// </summary>
	public void SaveAudio()
	{

		for (int i = 0; i < listAudio.Count; i++) 
		{

			ES2.Save (listAudio [i].audio.volume, "Setting.txt?tag=" + listAudio [i].audio.name);

			for (int j = 0; j < listAudio [i].listImage.Count; j++) 
			{

				ES2.Save<Color32> (listAudio [i].listImage [i].color, "Setting.txt?tag=" + listAudio [i].audio.name + listAudio [i].listImage [i].name);

			}

		}

	}

	/// <summary>
	/// Metodo che carica i volumi	
	/// </summary>
	public void LoadAudio()
	{

		if (ES2.Exists ("Setting.txt")) 
		{

			for (int i = 0; i < listAudio.Count; i++) 
			{

				//ES2.Load<float> ("Setting.txt?tag=" + listAudio [i].name);

			}

		} else {

			Debug.Log ("Il file non esiste");

		}

	}



}
