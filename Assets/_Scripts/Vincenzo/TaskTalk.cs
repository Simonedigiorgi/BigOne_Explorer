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

    GameObject player;

    public override void ReadyTask()
    {
        base.ReadyTask();

        Npc[] npcs = FindObjectsOfType<Npc>();
        Npc npc = null;

        for(int i = 0; i < npcs.Length; i++)
        {
            if(npcs[i].npc == npcAssociated)
            {
                npc = npcs[i];
            }
        }

        CompassLocation compass = GameManager.instance.gadgetManager.GetGadgetByType(GadgetManager.GadgetType.COMPASS).GetComponent<CompassLocation>();
        compass.ChangeTargetMission(npc.transform.parent.gameObject);
    }

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
            UIManager.instance.HideDialoguePanel();
            StartCoroutine(CompletingTask());
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

        if(gadgetsReward.Length > 0)
        {
            foreach (GadgetManager.GadgetType gadget in gadgetsReward)
            {
                Gadget gadgetToActivate = GameManager.instance.gadgetManager.gadgets.Find(x => x.gadgetType == gadget);
                gadgetToActivate.EnableGadget();
            }
        }
        

    }


}
