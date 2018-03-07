using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UTJ.Alembic;

public class PickaxeAction : vTriggerGenericAction {

    private GameObject poketShovel;                                                 // Pala (Tasca)
    private GameObject handShovel;                                                  // Pala (Mano)
    private AlembicStreamPlayer alembic;
    private bool destroyed;

    protected override void Start()
    {
        alembic = this.transform.parent.GetComponentInChildren<AlembicStreamPlayer>();
        destroyed = false;

        base.Start();

        poketShovel = GameObject.FindGameObjectWithTag("PalaPoket");                // Trova il GameObject con la TAG "PalaPoket"
        handShovel = GameObject.FindGameObjectWithTag("PalaHand");                  // Trova il GameObject con la TAG "PalaHand"

        poketShovel.transform.GetChild(0).gameObject.SetActive(true);               // Prendi il Figlio
        handShovel.transform.GetChild(0).gameObject.SetActive(false);               // Prendi il Figlio

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
        handShovel.transform.GetChild(0).gameObject.SetActive(true);
        poketShovel.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(4.4f);
        handShovel.transform.GetChild(0).gameObject.SetActive(false);
        poketShovel.transform.GetChild(0).gameObject.SetActive(true);
        destroyed = true;
    }
}
