using Invector.CharacterController;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskInteract : Task 
{

    //public List<String> taskObjectsName;
    public string tagTaskObjects;

    //protected GameObject[] taskObjects;
    protected int taskObjectsNumber;
    protected int allTaskObjectsNumber;
    public List<GameObject> taskObjects;

    protected virtual void InitTaskObjects()
    {
        GameObject[] taskArrayObjects = GameObject.FindGameObjectsWithTag(tagTaskObjects);
        taskObjects = new List<GameObject>(taskArrayObjects);

        allTaskObjectsNumber = taskObjects.Count;
        //taskObjectsName = new List<string>();

        for(int i = 0; i < allTaskObjectsNumber; i++)
        {
            GameObject action = taskObjects[i].transform.GetChild(0).gameObject;
            SetInteractableListener(action);

            //taskObjectsName.Add(taskObjects[i].name);

            Database.InteractableObject interactableObject = new Database.InteractableObject(
                (InteractableType)Enum.Parse(typeof(InteractableType), tagTaskObjects.ToUpper()), taskObjects[i].name, true, taskScene);
            Database.interactableObjects.Add(interactableObject);
        }
        
        QuestManager.instance.CurrentTarget += "\n" + tagTaskObjects + ": " + taskObjectsNumber + "/" + allTaskObjectsNumber;
    }

    protected virtual void LoadTaskObjects()
    {
        taskObjects.Clear();
        foreach(Database.InteractableObject interactable in Database.interactableObjects)
        {
            if(interactable.type == (InteractableType)Enum.Parse(typeof(InteractableType), tagTaskObjects.ToUpper()) && interactable.isInteractable) 
            {
                GameObject action = GameObject.Find(interactable.interactableName).transform.GetChild(0).gameObject;
                SetInteractableListener(action);

                taskObjects.Add(action.transform.parent.gameObject);
            }
        }
        QuestManager.instance.CurrentTarget = taskName + "\n" + tagTaskObjects + ": " + taskObjectsNumber + "/" + allTaskObjectsNumber;
    }

    protected virtual void SetTaskObject(GameObject interactable)
    {
        Database.interactableObjects.Find(x => x.interactableName == interactable.name).isInteractable = false;
        taskObjects.Remove(interactable);
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

    public override void EnableTask()
    {
        base.EnableTask();
        this.taskObjects.Clear();
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
                UpdateCompassObjects(action.transform.parent.gameObject);
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
                UpdateCompassObjects(action.transform.parent.gameObject);

                SetTaskObject(action.transform.parent.gameObject);
            });
        }

        actionComponent.OnPlayerEnter.AddListener(() => UIManager.instance.ShowHelpKeyPanel());
        actionComponent.OnPlayerExit.AddListener(() => UIManager.instance.HideHelpKeyPanel());

    }

    protected virtual void SetCompassObjects(List<GameObject> compassObjects)
    {
        CompassLocation compass = GameManager.instance.gadgetManager.gadgets.Find(x => x.gadgetType == GadgetManager.GadgetType.COMPASS).GetComponent<CompassLocation>();

        compass.listObjects = new List<GameObject>(compassObjects);

        compass.ChangeTargetMissionSequenzialy();

    }

    protected virtual void UpdateCompassObjects(GameObject compassObjectToDelete)
    {
        CompassLocation compass = GameManager.instance.gadgetManager.gadgets.Find(x => x.gadgetType == GadgetManager.GadgetType.COMPASS).GetComponent<CompassLocation>();
        GameObject objectToDestroy = compass.listObjects.Find(x => x.name == compassObjectToDelete.name);
        compass.listObjects.Remove(objectToDestroy);
    }
}
