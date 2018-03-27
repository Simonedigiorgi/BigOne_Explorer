using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateEquip : MonoBehaviour {

    private bool hasTrigger;

    void Update () {

        if (hasTrigger)
            transform.Rotate(Vector3.up * 20 * Time.deltaTime);

        /*if(transform.GetChild(0).GetComponent<GrabAction>().isGrabbed == true)
        {
            transform.Rotate(Vector3.up * 150 * Time.deltaTime);
            StartCoroutine(Disappear());
        }*/
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // && QUEST EQUIPAGGIAMENTO ENABLED
        {
            transform.DOMoveY(1f, 0.3f);
            hasTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        /*if (other.gameObject.CompareTag("Player") && transform.GetChild(0).GetComponent<GrabAction>().isGrabbed == false) // && QUEST EQUIPAGGIAMENTO ENABLED
        {
            transform.DOMoveY(0.5f, 0.3f);
            hasTrigger = false;
        }*/
    }

    public IEnumerator Disappear()
    {
        yield return new WaitForSeconds(2);
        transform.DOScale(0, 0.5f);

        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
