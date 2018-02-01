using Invector.CharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTalk : Task 
{
    public Npc.NpcType npcAssociated;
    public TextAsset taskDialogue;
    public int currentDialogue = 0;
    public GadgetManager.GadgetType[] gadgetsReward;

    GadgetManager gadgetManager;
    GameObject player;

    public override void ActiveTask()
    {
        base.ActiveTask();
        //DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        DialogueManager.instance.SetDialogue(this.taskDialogue, false);


    }

    public override void DoTask()
    {
        if (currentDialogue >= taskDialogue.ToString().Split('\n').Length-1)
        {
            CompleteTask();
        }
        else
        {
            //DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
            DialogueManager.instance.SwitchDialogues(taskDialogue.ToString().Split('\n'));
        }
    }

    public override void CompleteTask()
    {

        base.CompleteTask();

        //DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        UIManager.instance.HideDialoguePanel();
        gadgetManager = FindObjectOfType<GadgetManager>();
        if(gadgetsReward.Length > 0)
        {
            foreach (GadgetManager.GadgetType gadget in gadgetsReward)
            {
                gadgetManager.ActivateGadget(gadget, true);
            }
        }
        

    }


}
