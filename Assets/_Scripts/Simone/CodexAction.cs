using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodexAction : vTriggerGenericAction {

    public GameObject codex;
    [SerializeField] private bool isCodex;                                                          // Il Codex è attivo?

	protected override void Start () {

        base.Start();
        OnDoAction.AddListener(() => GetCodex());

    }
	
    public void GetCodex()
    {
        isCodex = true;
        codex.SetActive(true);
    }
}
