using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateEquip : MonoBehaviour {

    private bool hasTrigger;

    void Update () {

        if (hasTrigger)
            transform.Rotate(Vector3.up * 20 * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.DOMoveY(1f, 0.3f);
            hasTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.DOMoveY(0.5f, 0.3f);
            hasTrigger = false;
        }
    }
}
