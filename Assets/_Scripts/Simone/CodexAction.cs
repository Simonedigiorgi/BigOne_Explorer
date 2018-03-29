using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodexAction : vTriggerGenericAction {

    private GameObject codex;
    [SerializeField] private bool isCodex;

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
