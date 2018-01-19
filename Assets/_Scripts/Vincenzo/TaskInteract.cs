using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskInteract : Task 
{

    public List<String> taskObjectsName;
    public string tagTaskObjects;
    public int taskObjectsNumber;

    void InitTaskObjects()
    {
        GameObject[] taskObjects = GameObject.FindGameObjectsWithTag(tagTaskObjects);
        taskObjectsNumber = taskObjects.Length;
        taskObjectsName = new List<string>();

        for(int i = 0; i < taskObjectsNumber; i++)
        {
            taskObjects[i].transform.GetChild(0).gameObject.SetActive(true);
            taskObjectsName.Add(taskObjects[i].name); 
            Database.InteractableObject interactableObject = new Database.InteractableObject(
                (InteractableType)Enum.Parse(typeof(InteractableType), tagTaskObjects.ToUpper()), taskObjects[i].name, true, taskScene);
            Database.interactableObjects.Add(interactableObject);
        }
    }

    void LoadTaskObjects()
    {
        taskObjectsName.Clear();
        foreach(Database.InteractableObject interactable in Database.interactableObjects)
        {
            if(interactable.type == (InteractableType)Enum.Parse(typeof(InteractableType), tagTaskObjects.ToUpper()))
            {
                GameObject.Find(interactable.interactableName).transform.GetChild(0).gameObject.SetActive(true);
                taskObjectsName.Add(interactable.interactableName);
            }
        }
    }

    public void SetTaskObject(GameObject interactable)
    {
        Database.interactableObjects.Find(x => x.interactableName == interactable.name).isInteractable = false;
        taskObjectsName.Remove(interactable.name);
        Destroy(interactable);
        taskObjectsNumber--;
        if(taskObjectsNumber <= 0)
        {
            this.CompleteTask();
        }
    }

    public override void ReadyTask()
    {
        base.ReadyTask();

        if(!Database.interactableObjects.Exists(x => x.type == (InteractableType)Enum.Parse(typeof(InteractableType), tagTaskObjects.ToUpper())))
        {
            this.InitTaskObjects();
        }
        else
        {
            LoadTaskObjects();
        }

    }
}
