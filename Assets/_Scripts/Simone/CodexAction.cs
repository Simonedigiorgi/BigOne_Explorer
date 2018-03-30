﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

public class CodexAction : vTriggerGenericAction {

    public GameObject CodexUI;

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

        CodexUI.SetActive(true);

        HUD hud = GameObject.Find("PauseMenu").GetComponent<HUD>();

        if (codex)
        {
            if (hud.GetMenuIsOpen() == false)
            {
                codex.gameObject.SetActive(true);
                codex.MoveOnCodex("Open");
                hud.SetCodexMenuIsOpen(false);
                vThirdPersonController.instance.GetComponent<GenericSettings>().LockPlayer();
            }
        }


    }
}
