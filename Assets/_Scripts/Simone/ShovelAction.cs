using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelAction : vTriggerGenericAction {

    private GameObject poketShovel;                                                 // Pala (Tasca)
    private GameObject handShovel;                                                  // Pala (Mano)

	protected override void Start ()
    {

        base.Start();

        poketShovel = GameObject.FindGameObjectWithTag("PalaPoket");                // Trova il GameObject con la TAG "PalaPoket"
        handShovel = GameObject.FindGameObjectWithTag("PalaHand");                  // Trova il GameObject con la TAG "PalaHand"

        poketShovel.transform.GetChild(0).gameObject.SetActive(true);               // Prendi il Figlio
        handShovel.transform.GetChild(0).gameObject.SetActive(false);               // Prendi il Figlio

        OnDoAction.AddListener(() => GetShovel());
    }
	
    public void GetShovel()
    {
        StartCoroutine(UseShovel());                                                // Attiva nel momento in cui il Player preme Azione sul collider dell'animazione
    }

    public IEnumerator UseShovel()                                                  // Attiva e disattiva la pala tra la Tasca e la Mano
    {
        handShovel.transform.GetChild(0).gameObject.SetActive(true);
        poketShovel.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(4.4f);
        handShovel.transform.GetChild(0).gameObject.SetActive(false);
        poketShovel.transform.GetChild(0).gameObject.SetActive(true);
    }




}
