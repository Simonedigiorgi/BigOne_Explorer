using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GaleCraterSoundManager : MonoBehaviour {

	public Musica2 music;
	public static bool isRadio = false;
	private int nStation = 0;
	public AudioMixer mixerMusic;
	public AudioMixer mixerMain;

	void Start()
	{

		music.GoStartMusic (0, 0);
		music.GoStartMusic (0, 1);
		music.GoStartMusic (0, 2);
		music.GoStartMusic (0, 3);
		music.GoStartMusic (0, 4);
		music.GoStartMusic (0, 5);

		mixerMusic.SetFloat("Volume", -80f);
		music.GoClusterFade (0);

	}

	void Update()
	{

		//Ovattato
		if (Input.GetKeyDown (KeyCode.O)) 
		{

			music.GoSnapShotFade (0);

		}

		//Non ovattato
		if (Input.GetKeyDown (KeyCode.P)) 
		{

			music.GoSnapShotFade (1);

		}

		if (Input.GetKeyDown (KeyCode.U)) 
		{

			music.GoPlayOneShot (2);

			if (isRadio == false) 
			{
				
				isRadio = true;
				//mixerMusic.SetFloat("Volume", ES2.Load<float> ("Setting.txt?tag="+mixerMusic.name));
				mixerMain.SetFloat("Volume", -80f);
				mixerMusic.SetFloat("Volume", 0f);

			} 
			else 
			{

				isRadio = false;
				//mixerMain.SetFloat("Volume", ES2.Load<float> ("Setting.txt?tag="+mixerMain.name));
				Debug.Log (ES2.Load<float> ("Setting.txt?tag=" + mixerMain.name));
				mixerMusic.SetFloat("Volume", -80f);
				mixerMain.SetFloat("Volume",  0f);

			}

		}

		/*if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{

			nStation++;

			if (nStation == 2) 
			{

				nStation = 0;

			}



			if (nStation == 1) 
			{
				
				music.GoClusterFade (1);

			}

			if (nStation == 0) 
			{

				music.GoClusterFade (0);

			}


		}*/
			

	}

}
