using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentData: MonoBehaviour {

	//Per identificare univocamente l'oggetto
	public int hashcode;
	[Header("Posizione elemento")]
	public Vector3 position;
	[Header("Oggetto distrutto?")]
	public bool isDestroyed;

	void Awake()
	{

		hashcode = this.gameObject.GetHashCode();

	}


}
