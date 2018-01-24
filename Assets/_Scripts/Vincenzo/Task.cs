using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour 
{
	
    public enum TaskState
    {
        DISABLED,
        ENABLED,
        READY,
        ACTIVED,
        COMPLETED
    }

    public TaskState currentState;
    public string taskName;
    public int taskPriority;
    public string taskScene;

    public virtual void EnableTask()
    {
        this.currentState = TaskState.ENABLED;
        Database.currentQuest.activedTask.currentState = TaskState.ENABLED;
        QuestManager.instance.currentTarget = "Viaggia verso " + this.taskScene;
    }

    public virtual void ReadyTask()
    {
        this.currentState = TaskState.READY;
        Database.currentQuest.activedTask.currentState = TaskState.READY;
        QuestManager.instance.currentTarget = this.taskName;
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
        QuestManager.instance.CheckQuest();
    }

}
