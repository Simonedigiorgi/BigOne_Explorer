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
    public string taskScene;

    protected DialogueManager dialogueManager;

    void Awake()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public virtual void EnableTask()
    {
        this.currentState = TaskState.ENABLED;
        Database.currentQuest.activedTask.currentState = TaskState.ENABLED;
    }

    public virtual void ActiveTask()
    {
        this.currentState = TaskState.ACTIVED;
        Database.currentQuest.activedTask.currentState = TaskState.ACTIVED;
    }

    public virtual void DoTask()
    {

    }

    public virtual void CompleteTask()
    {
        this.currentState = TaskState.COMPLETED;
        Database.currentQuest.activedTask.currentState = TaskState.COMPLETED;
        QuestManager.currentQuest.SwitchToNextTask();
    }

}
