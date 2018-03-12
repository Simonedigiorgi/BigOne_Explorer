﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UTJ.Alembic;

public class PickaxeAction : vTriggerGenericAction {

    private GameObject poketPickaxe;                                                 // Pala (Tasca)
    private GameObject handPickaxe;                                                  // Pala (Mano)
    private AlembicStreamPlayer alembic;
    private bool destroyed;

    protected override void Start()
    {
        alembic = this.transform.parent.GetComponentInChildren<AlembicStreamPlayer>();
        destroyed = false;

        base.Start();

        poketPickaxe = GameObject.FindGameObjectWithTag("PalaPoket");                // Trova il GameObject con la TAG "PalaPoket"
        handPickaxe = GameObject.FindGameObjectWithTag("PalaPickaxeHand");           // Trova il GameObject con la TAG "PalaHand"

        poketPickaxe.transform.GetChild(0).gameObject.SetActive(true);               // Prendi il Figlio
        handPickaxe.transform.GetChild(0).gameObject.SetActive(false);               // Prendi il Figlio

        OnDoAction.AddListener(() => GetPickaxe());
    }

    private void Update()
    {
        if (destroyed && alembic.currentTime <= alembic.endTime)
        {
            alembic.currentTime += Time.deltaTime;
        }
    }

    public void GetPickaxe()
    {
        StartCoroutine(UsePickaxe());                                                // Attiva nel momento in cui il Player preme Azione sul collider dell'animazione
    }

    public IEnumerator UsePickaxe()                                                  // Attiva e disattiva la pala tra la Tasca e la Mano
    {
        handPickaxe.transform.GetChild(0).gameObject.SetActive(true);
        poketPickaxe.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        handPickaxe.transform.GetChild(0).gameObject.SetActive(false);
        poketPickaxe.transform.GetChild(0).gameObject.SetActive(true);
        destroyed = true;
    }
}
