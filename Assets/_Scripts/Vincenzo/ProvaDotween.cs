using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ProvaDotween : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	

    protected virtual IEnumerator Prova()
    {
        Sequence mySequence = DOTween.Sequence();

        mySequence.Append(gameObject.transform.DOMoveX(50, 2));
        mySequence.Append(gameObject.transform.DOScaleY(10, 2));

        yield return mySequence.WaitForCompletion();

        Debug.Log("Ciao");
    }
}
