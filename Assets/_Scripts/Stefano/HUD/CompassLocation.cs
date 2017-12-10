using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassLocation : MonoBehaviour {

	public Vector3 NorthDirection;

	public Transform Player;
	public Quaternion MissionDirection;
	public Transform missionPlace;

	void Update() 
	{

		ChangeNorthDirection ();
		ChangeMissionDirection ();

	}

	public void ChangeNorthDirection()
	{

		NorthDirection.z = Player.eulerAngles.y;

	}

	//Metodo per ruotare il compasso 
	public void ChangeMissionDirection()
	{

		Vector3 dir = transform.position - missionPlace.position;
		MissionDirection = Quaternion.LookRotation (dir);
		MissionDirection.z = - MissionDirection.y;
		MissionDirection.x = 0;
		MissionDirection.y = 0;

		transform.localRotation = MissionDirection * Quaternion.Euler (NorthDirection);

	}

}
