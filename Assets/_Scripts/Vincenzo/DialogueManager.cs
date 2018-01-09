using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	public void SetDialogue(TextAsset dialogueText, bool defaultDialogue)
    {
        ShowDialog();
        string[] dialogues = (dialogueText.ToString()).Split('\n');
        if(!defaultDialogue)
        {
            SwitchDialogues(dialogues);
        }
        else
        {
            this.GetComponentInChildren<Text>().text = dialogues[Random.Range(0, dialogues.Length)];
        }
        
    }

    public void ShowDialog()
    {
        this.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.8f);
    }

    public void HideDialogue()
    {
        this.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
        this.GetComponentInChildren<Text>().text = "";
    }

    public void SwitchDialogues(string[] dialoguesToSwitch)
    {
        int dialoguePointer = QuestManager.currentQuest.taskActived.GetComponent<TaskTalk>().currentDialogue;
        this.GetComponentInChildren<Text>().text = dialoguesToSwitch[dialoguePointer];
        (QuestManager.currentQuest.taskActived.GetComponent<TaskTalk>().currentDialogue)++;
    }

}
