using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{

    public enum QuestState
    {
        DISABLED,
        ENABLED,
        ACTIVED,
        COMPLETED
    }

	public string questName;
    public QuestState currentState;
    public GameObject npcAssociated;
    public int priority;
    [Header("Dialogues for this quest")]
    [TextArea]
    public string[] dialogue;

    

}
