using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{

    public enum QuestState
    {
        DISABLED,
        ENABLED,
        COMPLETED
    }

    public QuestState currentState;
    public string questName;
    public int questPriority;
    public Task taskActived;

    public List<Task> questTasks;

    private void Awake()
    {
        questTasks = new List<Task>();
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            questTasks.Add(this.gameObject.transform.GetChild(i).gameObject.GetComponent<Task>());
        }

        if(this.currentState == QuestState.ENABLED)
        {
            taskActived = questTasks.Find(x => x.currentState == Task.TaskState.ENABLED);
        }


    }





























    /*public enum QuestState
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
    //public GameObject[] actions;
    public List<GameObject> actions;

    [HideInInspector]
    public int actionsNumber;

    public string questTag;

    [Header("Dialogues for this quest")]
    [TextArea]
    public string[] dialogue;

    [HideInInspector]
    public int currentDialogue = 0;

    void Start()
    {
        var tempActions = GameObject.FindGameObjectsWithTag(questTag);
        foreach(GameObject action in tempActions)
        {
            actions.Add(action);
        }
        actionsNumber = actions.Count;

        //print(actionsNumber);

    }*/

}
