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
        StartCoroutine(UseShovel());
    }

    public IEnumerator UseShovel()
    {
        handShovel.transform.GetChild(0).gameObject.SetActive(true);
        handShovel.transform.GetChild(0).GetComponent<Animator>().SetTrigger("ShovelApertura");
        poketShovel.transform.GetChild(0).gameObject.SetActive(false);

        yield return new WaitForSeconds(4.4f);

        handShovel.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Idle");
        handShovel.transform.GetChild(0).gameObject.SetActive(false);
        poketShovel.transform.GetChild(0).gameObject.SetActive(true);

        this.transform.parent.gameObject.SetActive(false);
        //Destroy(this.transform.parent.gameObject);


    }




}
