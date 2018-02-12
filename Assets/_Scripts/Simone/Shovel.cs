using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour {

    public GameObject poketShovel;
    public GameObject handShovel;

	// Use this for initialization
	void Start () {

        poketShovel.SetActive(true);
        handShovel.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetShovel()
    {
        StartCoroutine(UseShovel());
    }

    public IEnumerator UseShovel()
    {
        handShovel.SetActive(true);
        poketShovel.SetActive(false);
        yield return new WaitForSeconds(4.4f);
        handShovel.SetActive(false);
        poketShovel.SetActive(true);
    }




}
