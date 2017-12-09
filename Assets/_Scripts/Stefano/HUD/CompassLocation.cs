using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassLocation : MonoBehaviour {

	public Transform target;
	public float speed;

	void Update() 
	{
		Vector3 targetDir = target.position - transform.position;
		float step = speed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		transform.rotation = Quaternion.LookRotation(newDir);
	}

	//Metodo per ruotare il compasso 
	public void Compass()
	{



	}

}
