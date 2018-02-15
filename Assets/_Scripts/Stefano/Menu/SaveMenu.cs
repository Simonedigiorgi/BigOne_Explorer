using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SaveMenu : MonoBehaviour {

	#region Public 

	[Header("Settaggi audio")]
	public List<SettingAudio> listAudio;

	[Header("Slot dati")]
	public Text slot1;
	public Text slot2;
	public Text slot3;

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
		LoadSlotInfo ();

	}

	public void SaveSettinngs()
	{

		SaveAudio ();

	}

	#region Save

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

				ES2.Save<Color32> (listAudio [i].listImage [j].color, "Setting.txt?tag=" + listAudio [i].audio.name + listAudio [i].listImage [j].name);

			}

		}

	}

	#endregion

	#region Load

	/// <summary>
	/// Metodo che carica i volumi	
	/// </summary>
	public void LoadAudio()
	{

		if (ES2.Exists ("Setting.txt")) 
		{

			for (int i = 0; i < listAudio.Count; i++) 
			{

				listAudio [i].audio.volume = ES2.Load<float> ("Setting.txt?tag=" + listAudio [i].audio.name);

				for (int j = 0; j < listAudio [i].listImage.Count; j++) 
				{
					
					listAudio [i].listImage [j].color = ES2.Load<Color32> ("Setting.txt?tag=" + listAudio [i].audio.name + listAudio [i].listImage [j].name);

				}

			}

		} else {

			Debug.Log ("Il file non esiste");

		}

	}


	/// <summary>
	/// Metodo che carica le informazioni degli slot
	/// </summary>
	public void LoadSlotInfo()
	{

		if (ES2.Exists ("Slot1.txt")) {

			slot1.text = ES2.Load<string> ("Slot1.txt?tag=SaveTime");

		} else {

			slot1.text = "Empty";

		}

		if (ES2.Exists ("Slot2.txt")) {

			slot2.text = ES2.Load<string> ("Slot2.txt?tag=SaveTime");

		} else {

			slot2.text = "Empty";

		}

		if (ES2.Exists ("Slot3.txt")) {

			slot3.text = ES2.Load<string> ("Slot3.txt?tag=SaveTime");

		} else {

			slot3.text = "Empty";

		}


	}

	#endregion

}
