using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

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

        HUD hud = GameObject.Find("PauseMenu").GetComponent<HUD>();

        if (codex)
        {
            codex.gameObject.SetActive(true);
            codex.MoveOnCodex("Open");
            hud.setMenuIsOpen(true);
            vThirdPersonController.instance.GetComponent<GenericSettings>().LockPlayer();
        }


    }
}
