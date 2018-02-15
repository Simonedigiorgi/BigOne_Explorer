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
        QuestManager.instance.CurrentTarget = "Viaggia verso " + this.taskScene;

        CompassLocation compass = GameManager.instance.gadgetManager.GetGadgetByType(GadgetManager.GadgetType.COMPASS).GetComponent<CompassLocation>();
        Transform roverPosition = GameObject.Find("LAND ROVER").transform;
        compass.ChangeTargetMission(roverPosition);


    }

    public virtual void ReadyTask()
    {
        this.currentState = TaskState.READY;
        Database.currentQuest.activedTask.currentState = TaskState.READY;
        QuestManager.instance.CurrentTarget = this.taskName;
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
        QuestManager.instance.currentQuest.SwitchToNextTask();
        QuestManager.instance.CheckQuest();
    }

}
