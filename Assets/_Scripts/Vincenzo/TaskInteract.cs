using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskInteract : Task 
{

    public List<String> taskObjectsName;
    public string tagTaskObjects;
    public int taskObjectsNumber;
    public int allTaskObjectsNumber;

    protected virtual void InitTaskObjects()
    {
        GameObject[] taskObjects = GameObject.FindGameObjectsWithTag(tagTaskObjects);
        allTaskObjectsNumber = taskObjects.Length;
        taskObjectsName = new List<string>();

        for(int i = 0; i < allTaskObjectsNumber; i++)
        {
            GameObject action = taskObjects[i].transform.GetChild(0).gameObject;
            SetInteractableListener(action);

            taskObjectsName.Add(taskObjects[i].name); 
            Database.InteractableObject interactableObject = new Database.InteractableObject(
                (InteractableType)Enum.Parse(typeof(InteractableType), tagTaskObjects.ToUpper()), taskObjects[i].name, true, taskScene);
            Database.interactableObjects.Add(interactableObject);
        }

        QuestManager.instance.CurrentTarget += "\n" + tagTaskObjects + ": " + taskObjectsNumber + "/" + allTaskObjectsNumber;
    }

    protected virtual void LoadTaskObjects()
    {
        taskObjectsName.Clear();
        foreach(Database.InteractableObject interactable in Database.interactableObjects)
        {
            if(interactable.type == (InteractableType)Enum.Parse(typeof(InteractableType), tagTaskObjects.ToUpper()) && interactable.isInteractable) 
            {
                GameObject action = GameObject.Find(interactable.interactableName).transform.GetChild(0).gameObject;
                SetInteractableListener(action);

                taskObjectsName.Add(interactable.interactableName);
            }
        }
        QuestManager.instance.CurrentTarget = taskName + "\n" + tagTaskObjects + ": " + taskObjectsNumber + "/" + allTaskObjectsNumber;
    }

    protected virtual void SetTaskObject(GameObject interactable)
    {
        Database.interactableObjects.Find(x => x.interactableName == interactable.name).isInteractable = false;
        taskObjectsName.Remove(interactable.name);
        interactable.transform.GetChild(0).GetComponent<vTriggerGenericAction>().OnDoAction.RemoveListener(() => SetTaskObject(interactable));
        Destroy(interactable);
        taskObjectsNumber++;
        QuestManager.instance.CurrentTarget = taskName + "\n" + tagTaskObjects + ": " + taskObjectsNumber + "/" + allTaskObjectsNumber;
        if(taskObjectsNumber >= allTaskObjectsNumber)
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

    protected virtual void ShowHelpKey(GameObject actionAssociated)
    {
        if (Input.GetJoystickNames().Length > 0)
        {
            actionAssociated.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            actionAssociated.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    protected virtual void HideHelpKey(GameObject actionAssociated)
    {
        if (Input.GetJoystickNames().Length > 0)
        {
            actionAssociated.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            actionAssociated.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    protected virtual void SetInteractableListener(GameObject action)
    {
        action.SetActive(true);
        vTriggerGenericAction actionComponent = action.GetComponent<vTriggerGenericAction>();

        if (tagTaskObjects == "Equipaggiamento")
        {
            GadgetManager gadgetManager = FindObjectOfType<GadgetManager>();
            actionComponent.OnDoAction.AddListener(() =>
            {
                SetTaskObject(action.transform.parent.gameObject);
                Gadget gadget = gadgetManager.gadgets
                    .Find(x => x.gadgetType == (GadgetManager.GadgetType)Enum.Parse(typeof(GadgetManager.GadgetType), action.transform.parent.name.ToUpper()));
                gadget.isEnabled = true;
                /*gadgetManager = FindObjectOfType<GadgetManager>();
                GadgetManager.GadgetType gadget = (GadgetManager.GadgetType)Enum.Parse(typeof(GadgetManager.GadgetType), action.transform.parent.name.ToUpper());
                gadgetManager.ActivateGadget(gadget, true);*/
            });
        }
        else
        {
            actionComponent.OnDoAction.AddListener(() => SetTaskObject(action.transform.parent.gameObject));
        }

        //actionComponent.OnPlayerEnter.AddListener(() => ShowHelpKey(action));
        //actionComponent.OnPlayerExit.AddListener(() => HideHelpKey(action));

    }
}
