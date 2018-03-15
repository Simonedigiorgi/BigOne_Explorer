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
        openFlag = closeFlag.transform.GetChild(1).gameObject;

        closeFlag.transform.GetChild(0).gameObject.SetActive(false);                // Prendi il Figlio
        closeFlag.transform.GetChild(1).gameObject.SetActive(false);                // Prendi il Figlio

        OnDoAction.AddListener(() => GetFlag());
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
        this.transform.parent.GetChild(1).transform.position = 
            new Vector3(closeFlag.transform.GetChild(1).transform.position.x + 1.8f, 
                        closeFlag.transform.GetChild(1).transform.position.y - 1.2f, 
                        closeFlag.transform.GetChild(1).transform.position.z);
        closeFlag.transform.DetachChildren();
        
        yield return new WaitForSeconds(1f);

        openFlag.SetActive(false);
        this.transform.parent.GetChild(1).gameObject.SetActive(true);

        this.gameObject.SetActive(false);
    }
}
