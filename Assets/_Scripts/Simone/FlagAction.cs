using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagAction : vTriggerGenericAction {

    private GameObject closeFlag;                                                   // Prendi la Bandiera chiusa
    private GameObject openFlag;                                                    // Prendi la Bandiera aperta

    protected override void Start()
    {
        base.Start();

        closeFlag = GameObject.FindGameObjectWithTag("CloseFlag");
        //openFlag = GameObject.FindGameObjectWithTag("OpenFlag");

        closeFlag.transform.GetChild(0).gameObject.SetActive(false);                // Prendi il Figlio
        closeFlag.transform.GetChild(1).gameObject.SetActive(false);                // Prendi il Figlio

        OnDoAction.AddListener(() => GetFlag());
    }

    public void Update()
    {
        if(closeFlag.transform.GetChild(1).gameObject.activeSelf == true)
        {
            Debug.Log("Bandiera Posizionata");
            // Posiziona La bandiera nella (closeFlag.transform.GetChild(1).transform.position
        }
    }

    public void GetFlag()
    {
        StartCoroutine(UseFlag());
    }

    public IEnumerator UseFlag()
    {
        closeFlag.transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        closeFlag.transform.GetChild(0).gameObject.SetActive(false);
        closeFlag.transform.GetChild(1).gameObject.SetActive(true);
        closeFlag.transform.DetachChildren();

        Destroy(this.transform.parent.gameObject);
    }
}
