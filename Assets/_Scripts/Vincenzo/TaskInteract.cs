using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskInteract : Task 
{

    public string[] taskObjectsName;
    public string tagTaskObjects;
    public int taskObjectsNumber;

    public void GetTaskObjects()
    {
        GameObject[] taskObjects = GameObject.FindGameObjectsWithTag(tagTaskObjects);
        taskObjectsNumber = taskObjects.Length;
        taskObjectsName = new string[taskObjectsNumber];
        for(int i = 0; i < taskObjectsNumber; i++)
        {
            taskObjectsName[i] = taskObjects[i].name;
            Database.InteractableObject interactableObject = new Database.InteractableObject();
            interactableObject.interactableName = taskObjects[i].name;
            interactableObject.isInteractable = true;
            interactableObject.type = (InteractableType)Enum.Parse(typeof(InteractableType), tagTaskObjects.ToUpper());
            Database.interactableObjects.Add(interactableObject);
        }
    }

    public override void ReadyTask()
    {
        base.ReadyTask();

        if(taskObjectsName.Length <= 0)
        {
            this.GetTaskObjects();
        }
        

    }
}
