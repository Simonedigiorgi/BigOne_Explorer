using Invector.CharacterController;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskGadget : TaskInteract {

    public GadgetManager.GadgetType gadgetType;
    public string tagZone;

    Gadget gadget;
    GadgetManager gadgetManager;
    GameObject[] interactableZone;

    public override void ReadyTask()
    {
        base.ReadyTask();

        CompassLocation compass = GameManager.instance.gadgetManager.gadgets.Find(x => x.gadgetType == GadgetManager.GadgetType.COMPASS).GetComponent<CompassLocation>();
        compass.listObjects.Clear();

        interactableZone = GameObject.FindGameObjectsWithTag(tagZone);
        SetCompassObjects(interactableZone);

        gadgetManager = FindObjectOfType<GadgetManager>();
        gadget = GameManager.instance.gadgetManager.GetGadgetByType(gadgetType);

        foreach(string objectName in taskObjectsName)
        {
            Transform interactableObject = GameObject.Find(objectName).transform;
            gadget.listObjects.Add(interactableObject);
        }
    }

    protected override void SetInteractableListener(GameObject action)
    {
        vTriggerGenericAction actionComponent = action.GetComponent<vTriggerGenericAction>();

        actionComponent.OnDoAction.AddListener(() =>
        {
            UpdateCompassObjects(action.transform.parent.transform.parent.transform);
            SetTaskObject(action.transform.parent.gameObject);
        });
    }

    protected override void SetTaskObject(GameObject interactable)
    {
        gadget.listObjects.Remove(interactable.transform);
        base.SetTaskObject(interactable);   
    }



}
