using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{

    public enum QuestState
    {
        DISABLED,
        ENABLED,
        ACTIVING,
        ACTIVED,
        COMPLETED
    }

	public string questName;
    public QuestState currentState;
    public GameObject npcAssociated;
    public int priority;
    public GameObject[] actions;

    [Header("Dialogues for this quest")]
    [TextArea]
    public string[] dialogue;
    public int currentDialogue = 0;

    private void Start()
    {
        actions = GameObject.FindGameObjectsWithTag("NpcActivity");
    }

}
