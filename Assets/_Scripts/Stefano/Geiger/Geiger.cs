﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Geiger : MonoBehaviour 
{

	#region Public
	public bool equip = false;
	[Header("Lista di oggetti da cercare nella scena")]
	public List<Transform> listObjects;
	[Header("Suono geiger LOW")]
	public AudioClip Geiger_LOW;
	[Header("Suono geiger HIGH")]
	public AudioClip Geiger_HIGH;
	[Header("\n")]
	public AudioSource audioSource;
	[Header("Distanza vicina alle radiazioni")]
	public float vicino;
	public Color coloreVicino;
	[Header("Media distanza dalle radiazioni")]
	public Color coloreMedio;
	[Header("Distanza lontana dalle radiazioni")]
	public float lontano;
	public Color coloreLontano;
	[Header("Effetto circolare")]
	public ParticleSystem ripple;
	#endregion

	#region Private 
	private float timer;
	private float currentDistance;

	private bool Semaforo1 = false;
	private bool Semaforo2 = false;
	private bool Semaforo3 = false;
	#endregion

	// Update is called once per frame
	void Update () 
	{

		if (equip == true) 
		{
			
			SearchObject ();

			if (currentDistance <= vicino && Semaforo1 == false) 
			{

				audioSource.clip = Geiger_HIGH;
				audioSource.Play ();

				ChangeRippleColor (coloreVicino);

				Semaforo1 = true;
				Semaforo2 = false;
				Semaforo3 = false;

			} 
			else if (currentDistance > vicino && currentDistance <= lontano && Semaforo2 == false) 
			{

				audioSource.clip = Geiger_LOW;
				audioSource.Play ();

				ChangeRippleColor (coloreMedio);

				Semaforo1 = false;
				Semaforo2 = true;
				Semaforo3 = false;

			} 
			else if (currentDistance > lontano && Semaforo3 == false)
			{

				audioSource.Stop ();

				ChangeRippleColor (coloreLontano);

				Semaforo1 = false;
				Semaforo2 = false;
				Semaforo3 = true;

			}
		}

	}

	/// <summary>
	/// Oggetto da cercare calcolando la distanza
	/// </summary>
	private void SearchObject()
	{

		Transform obj = listObjects[0];
		float distance;
		float compareDistance = Vector3.Distance(listObjects [0].position, transform.position);

		for (int i = 0; i < listObjects.Count; i++) 
		{

			distance = Vector3.Distance (listObjects [i].position, transform.position);

			if (distance <= compareDistance) 
			{

				obj = listObjects [i];
				compareDistance = distance;

			}

		}

		currentDistance = Vector3.Distance(obj.position,transform.position);

		//Debug.Log (currentDistance);

	}

	#region Ripple

	/// <summary>
	/// Metodo che cambia il colore al particle system
	/// </summary>
	private void ChangeRippleColor(Color c)
	{

		var main = ripple.main;
		c.a = 255;
		main.startColor = c;

	}

	#endregion



}
