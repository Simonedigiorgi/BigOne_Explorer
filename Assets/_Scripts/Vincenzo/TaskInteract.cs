using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskInteract : Task 
{

    public GameObject[] taskObjects;
    public string tagTaskObjects;
    public int taskObjectsNumber;

    public void GetTaskObjects()
    {
       
        taskObjects = GameObject.FindGameObjectsWithTag(tagTaskObjects);
        taskObjectsNumber = taskObjects.Length;
        
    }

    public override void ReadyTask()
    {
        base.ReadyTask();

        this.GetTaskObjects();

    }
}
