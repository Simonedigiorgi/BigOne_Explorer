using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ossigeno : MonoBehaviour {

	[Header("Ossigeno in percentuale")]
	public int O2;
	[Header("Tempo per di durata per ogni percentuale")]
	public float timeRange;
	[Header("Barra di ossigeno")]
	public Slider sliderO2;  
	[Header("Immagine della barra dell'ossigeno")]
	public Image bar;
	[Header("Colore della barra")]
	public Color colorBar;
	[Header("Testo della bombola di ossigeno")]
	public Text textO2;

	private float timer = 0; 

	void Awake()
	{

		sliderO2.value = sliderO2.maxValue;
		SetMaxO2 ();
	
	}

	void Update()
	{

		timer += Time.deltaTime;

		//Facciamo scendere il livello di ossigeno
		if (timer >= timeRange && O2 >= 1) 
		{

			timer = 0;
			O2decreases ();

		}

		//Controlliamo il livello di ossigeno e cambiamo colore
		if (O2 <= 50) 
		{

			ChangeColorOfBar ();

		}

	}

	//Perdere ossigeno nel tempo
	public void O2decreases()
	{

		O2 -= 1;
		sliderO2.value = O2;
		textO2.text = O2.ToString () + "%";

	}

	//Metodo che setta al massimo la bombola
	public void SetMaxO2()
	{

		O2 = 100;
		textO2.text = O2.ToString () + "%";

	}

	//Metodo che trasforma la barra dal colore blu al colore rosso
	public void ChangeColorOfBar()
	{

		bar.color = colorBar;

	}

	//Controlla se c'è ancora ossigeno
	public bool CheckO2()
	{

		return O2 > 0;

	}

}
