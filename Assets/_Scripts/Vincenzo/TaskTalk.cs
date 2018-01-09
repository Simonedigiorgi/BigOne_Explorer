using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTalk : Task 
{
    public Npc.NpcType npcAssociated;
    public TextAsset taskDialogue;
    public int currentDialogue = 0;

    public void DoTask()
    {
        if(currentDialogue >= taskDialogue.ToString().Split('\n').Length)
        {
            CompleteTask();
        }
        else
        {
            dialogueManager.SetDialogue(this.taskDialogue, false);
        }
    }

    public override void CompleteTask()
    {
        
        base.CompleteTask();

    }


}
