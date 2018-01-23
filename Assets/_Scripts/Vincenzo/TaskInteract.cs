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
            GameObject action = taskObjects[i].transform.GetChild(0).gameObject;

            action.SetActive(true);

            action.GetComponent<vTriggerGenericAction>().OnDoAction.AddListener(() => SetTaskObject(action.transform.parent.gameObject));

            

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
            if(interactable.type == (InteractableType)Enum.Parse(typeof(InteractableType), tagTaskObjects.ToUpper()) && interactable.isInteractable) 
            {
                GameObject action = GameObject.Find(interactable.interactableName).transform.GetChild(0).gameObject;
                action.SetActive(true);
                action.GetComponent<vTriggerGenericAction>().OnDoAction.AddListener(() => SetTaskObject(action.transform.parent.gameObject));

                taskObjectsName.Add(interactable.interactableName);
            }
        }
    }

    public void StampaGesu()
    {
        print("Gesù");
    } 

    public void SetTaskObject(GameObject interactable)
    {
        Database.interactableObjects.Find(x => x.interactableName == interactable.name).isInteractable = false;
        taskObjectsName.Remove(interactable.name);
        interactable.transform.GetChild(0).GetComponent<vTriggerGenericAction>().OnDoAction.RemoveListener(() => SetTaskObject(interactable));
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
