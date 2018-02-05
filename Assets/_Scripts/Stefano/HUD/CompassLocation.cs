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
