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

}
