using Invector.CharacterController;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskGadget : TaskInteract {

    public GadgetManager.GadgetType gadgetType;

    Gadget gadget;
    GadgetManager gadgetManager;

    public override void ReadyTask()
    {
        base.ReadyTask();

        gadgetManager = FindObjectOfType<GadgetManager>();
        gadget = gadgetManager.GetGadgetByType(gadgetType);
        foreach(string objectName in taskObjectsName)
        {
            Transform interactableObject = GameObject.Find(objectName).transform;
            gadget.listObjects.Add(interactableObject);
        }
    }

    protected override void SetInteractableListener(GameObject action)
    {
        base.SetInteractableListener(action);
        action.SetActive(false);
    }

    protected override void SetTaskObject(GameObject interactable)
    {
        gadget.listObjects.Remove(interactable.transform);
        base.SetTaskObject(interactable);   
    }



}
