using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassLocation : Gadget {

	#region Public
	public Vector3 NorthDirection;
	public Transform Player;
	public Quaternion MissionDirection;
	[Header("Pool di posizioni che potrà puntare la bussol")]
	public List<Transform> listTarget;
	[Header("Target corrente a cui punta la bussola")]
	public Transform missionPlace;
	#endregion

	void Update() 
	{
        UseGadget();
	}

    public override void SetGadget()
    {
        base.SetGadget();
        if(this.isEquipped)
        {
            this.transform.parent.gameObject.SetActive(true);
        }
        else
        {
            this.transform.parent.gameObject.SetActive(false);
        }
    }

    protected override void UseGadget()
    {
        if(this.isEquipped)
        {
			//Per cambiare runtime l'obbiettivo
			ChangeTargetMissionSequenzialy ();
            ChangeNorthDirection();

            if (missionPlace)
                ChangeMissionDirection();
            else
                print("No Target");
        }
    }

    //Metodo per aggionrare il punto di riferimento
    private void ChangeNorthDirection()
	{

		NorthDirection.z = Player.eulerAngles.y;

	}

	//Metodo per ruotare il compasso 
	private void ChangeMissionDirection()
	{

		Vector3 dir = transform.position - missionPlace.position;
		MissionDirection = Quaternion.LookRotation (dir);
		MissionDirection.z = - MissionDirection.y;
		MissionDirection.x = 0;
		MissionDirection.y = 0;

		transform.localRotation = MissionDirection * Quaternion.Euler (NorthDirection);

	}

	//Metodo per cambiare il target della missione
	public void ChangeTargetMission(Transform newMissionPlace)
	{

		missionPlace = newMissionPlace;

	}

	/// <summary>
	/// Metodo che permette alla bussola di puntare sempre verso l'obbiettivo più vicino
	/// </summary>
	public void ChangeTargetMissionSequenzialy()
	{

		if(listTarget.Count > 0)
			ChangeTargetMission (SearchObject ());

	}

	/// <summary>
	/// Oggetto da cercare calcolando la distanza
	/// </summary>
	private Transform SearchObject()
	{

		Transform obj = listTarget[0];
		float distance;
		float compareDistance = Vector3.Distance(listTarget [0].position, transform.position);

		for (int i = 0; i < listTarget.Count; i++) 
		{

			distance = Vector3.Distance (listTarget [i].position, transform.position);

			if (distance <= compareDistance) 
			{

				obj = listTarget [i];
				compareDistance = distance;
				return obj;

			}

		}

		return null;

	}

	//Metodo che non rende visibile il GPS
	public void DisableCompass()
	{

		GameObject.Find("Canvas_bussola").layer = 20;


	}

	//Metodo che rende visibile il GPS
	public void EnableCompass()
	{

		GameObject.Find("Canvas_bussola").layer = 19;

	}

}
