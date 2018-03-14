﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAction : vTriggerGenericAction
{

    public Transform playerLeftForeArm;                                         // BRACCIO SINISTRO (mixamorig:LeftForeArm)
    public Transform playerLeftHand;                                            // MANO SINISTRA (mixamorig:LeftHand) 
    private bool isGrabbed;

    protected override void Start()
    {

        base.Start();

        OnDoAction.AddListener(() => Grab());
    }

    void Update () {

        if (isGrabbed)
        {
            //transform.GetChild(0).parent = playerLeftHand.parent.transform;
            transform.GetChild(0).parent.gameObject.SetActive(false);
            isGrabbed = false;

            // PER SETTARE IN MODO SPECIFICO L'AGGANCIO BISOGNA MODIFICARE LE POSIZIONI
            /*playerLeftArm.transform.GetChild(1).position = new Vector3
               (playerLeftArm.transform.GetChild(1).position.x - 0f,
                playerLeftArm.transform.GetChild(1).position.y - 0f,
                playerLeftArm.transform.GetChild(1).position.z - 0f); */

        }
	}

    public void Grab()
    {
        StartCoroutine(GrabCoroutine());
    }

    private IEnumerator GrabCoroutine()
    {
        yield return new WaitForSeconds(1.6f);                              // Tempo prima di raccogliere l'oggetto                    
        isGrabbed = true;

        /*yield return new WaitForSeconds(4.0f);
        playerLeftForeArm.transform.GetChild(1).gameObject.SetActive(false);*/   // Disattiva l'oggetto

        //Destroy(playerLeftHand.transform.GetChild(1).gameObject);

    }
}
