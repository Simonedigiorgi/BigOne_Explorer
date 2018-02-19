using Invector.CharacterController;
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

    protected GameObject[] taskObjects;

    protected virtual void InitTaskObjects()
    {
        taskObjects = GameObject.FindGameObjectsWithTag(tagTaskObjects);

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
        UIManager.instance.HideHelpKeyPanel();
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
            SetCompassObjects(taskObjects);
        }
        else
        {
            LoadTaskObjects();
            SetCompassObjects(taskObjects);
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
                UpdateCompassObjects(action.transform.parent.transform);
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
            actionComponent.OnDoAction.AddListener(() =>{
                UpdateCompassObjects(action.transform.parent.transform);
                SetTaskObject(action.transform.parent.gameObject);
            });
        }

        actionComponent.OnPlayerEnter.AddListener(() => UIManager.instance.ShowHelpKeyPanel());
        actionComponent.OnPlayerExit.AddListener(() => UIManager.instance.HideHelpKeyPanel());

    }

    protected virtual void SetCompassObjects(GameObject[] compassObjects)
    {
        CompassLocation compass = GameManager.instance.gadgetManager.gadgets.Find(x => x.gadgetType == GadgetManager.GadgetType.COMPASS).GetComponent<CompassLocation>();

        for (int i = 0; i < compassObjects.Length; i++)
        {
            compass.listObjects.Add(compassObjects[i].transform);
        }

        compass.ChangeTargetMissionSequenzialy();

    }

    protected virtual void UpdateCompassObjects(Transform compassObjectToDelete)
    {
        CompassLocation compass = GameManager.instance.gadgetManager.gadgets.Find(x => x.gadgetType == GadgetManager.GadgetType.COMPASS).GetComponent<CompassLocation>();
        Transform objectToDestroy = compass.listObjects.Find(x => x.name == compassObjectToDelete.name);
        compass.listObjects.Remove(objectToDestroy);
    }
}
