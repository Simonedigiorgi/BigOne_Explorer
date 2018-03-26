using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GrabAction : vTriggerGenericAction
{
    private bool isGrabbed;

    protected override void Start()
    {
        base.Start();
        OnDoAction.AddListener(() => Grab());
    }

    void Update () {

        if (isGrabbed)
        {
            // Destroy(this.transform.parent.gameObject);
        }
	}

    public void Grab()
    {

        StartCoroutine(GrabCoroutine());
    }

    private IEnumerator GrabCoroutine()
    {
        isGrabbed = true;
        yield return new WaitForSeconds(2);                              // Tempo prima di raccogliere l'oggetto 
        transform.parent.gameObject.transform.DOScale(0, 1);
        yield return new WaitForSeconds(1f);
        transform.parent.gameObject.SetActive(false);



    }
}
