using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UTJ.Alembic;
using Invector.CharacterController;

public class ShovelAction : vTriggerGenericAction {

    private GameObject poketShovel;                                                 // Pala (Tasca)
    private GameObject handShovel;                                                  // Pala (Mano)
    private AlembicStreamPlayer alembic;
    private bool destroyed;

    protected override void Start ()
    {
        alembic = this.transform.parent.GetComponentInChildren<AlembicStreamPlayer>();
        destroyed = false;

        base.Start();

        poketShovel = GameObject.FindGameObjectWithTag("PalaPoket");                // Trova il GameObject con la TAG "PalaPoket"
        handShovel = GameObject.FindGameObjectWithTag("PalaHand");                  // Trova il GameObject con la TAG "PalaHand"

        poketShovel.transform.GetChild(0).gameObject.SetActive(true);               // Prendi il Figlio
        handShovel.transform.GetChild(0).gameObject.SetActive(false);               // Prendi il Figlio

        OnDoAction.AddListener(() => GetShovel());
    }

    private void Update()
    {
        if (destroyed && alembic.currentTime <= alembic.endTime)
        {
            alembic.currentTime += Time.deltaTime;
        }
    }

    public void GetShovel()
    {
        StartCoroutine(UseShovel());                                                // Attiva nel momento in cui il Player preme Azione sul collider dell'animazione
    }

    public IEnumerator UseShovel()                                                  // Attiva e disattiva la pala tra la Tasca e la Mano
    {
        Animator playerAnimator = vThirdPersonController.instance.GetComponent<Animator>();
        int shovelState = playerAnimator.GetInteger("ShovelState");

        playerAnimator.SetInteger("ShovelState", 0);
        handShovel.transform.GetChild(0).gameObject.SetActive(true);
        handShovel.transform.GetChild(0).GetComponent<Animator>().SetTrigger("ShovelApertura");
        poketShovel.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(8.8f);

        playerAnimator.SetInteger("ShovelState", 3);
        handShovel.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Idle");
        handShovel.transform.GetChild(0).gameObject.SetActive(false);
        poketShovel.transform.GetChild(0).gameObject.SetActive(true);
        destroyed = true;
    }




}
