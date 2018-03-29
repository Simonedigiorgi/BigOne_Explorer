using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodexAction : vTriggerGenericAction {

	private CodexStefano codex;
    [SerializeField] private bool isCodex;

	protected override void Start () 
	{

        codex = FindObjectOfType<CodexStefano>();

        base.Start();
        OnDoAction.AddListener(() => GetCodex());
    }
	
    public void GetCodex()
    {
        isCodex = true;

        if (codex)
        {
            codex.gameObject.SetActive(true);
            codex.MoveOnCodex("Open");
        }


    }
}
