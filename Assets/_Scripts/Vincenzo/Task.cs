using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour 
{
	
    public enum TaskState
    {
        DISABLED,
        ENABLED,
        ACTIVED,
        COMPLETED
    }

    public TaskState currentState;
    public string taskName;
    public int taskPriority;

    protected DialogueManager dialogueManager;

    void Awake()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public virtual void ActiveTask()
    {
        this.currentState = TaskState.ACTIVED;
    }

    public virtual void DoTask()
    {

    }

    public virtual void CompleteTask()
    {
        this.currentState = TaskState.COMPLETED;
        QuestManager.currentQuest.SwitchToNextTask();
    }

}
