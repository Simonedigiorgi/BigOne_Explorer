using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProveAction : vTriggerGenericAction {

    protected override void Start()
    {

        base.Start();

        OnDoAction.AddListener(() => GetProve());
    }

    
    public void GetProve()
    {
        
		Destroy (this.transform.parent.gameObject);                                        // Attiva nel momento in cui il Player preme Azione sul collider dell'animazione
    }

}
