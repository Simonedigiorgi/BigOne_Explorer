using Invector.CharacterController;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskGadget : TaskInteract {

    public GadgetManager.GadgetType gadgetType;
    public string tagZone;

    Gadget gadget;
    //GadgetManager gadgetManager;
    List<GameObject> interactableListZone;

    public override void EnableTask()
    {
        base.EnableTask();
        gadget = GameManager.instance.gadgetManager.GetGadgetByType(gadgetType);
        gadget.listObjects.Clear();
    }

    public override void ReadyTask()
    {
        base.ReadyTask();

        CompassLocation compass = GameManager.instance.gadgetManager.gadgets.Find(x => x.gadgetType == GadgetManager.GadgetType.COMPASS).GetComponent<CompassLocation>();
        compass.listObjects.Clear();

        GameObject[] interactableArrayZone = GameObject.FindGameObjectsWithTag(tagZone);
        interactableListZone = new List<GameObject>(interactableArrayZone);
        SetCompassObjects(interactableListZone);

        gadget = GameManager.instance.gadgetManager.GetGadgetByType(gadgetType);

        gadget.listObjects.Clear();
        gadget.listObjects = new List<GameObject>(taskObjects);
        
    }

    protected override void SetInteractableListener(GameObject action)
    {
        vTriggerGenericAction actionComponent = action.GetComponent<vTriggerGenericAction>();

        actionComponent.OnDoAction.AddListener(() =>
        {
            SetTaskObject(action.transform.parent.gameObject);
        });
        actionComponent.OnPlayerEnter.AddListener(() => UIManager.instance.ShowHelpKeyPanel());
        actionComponent.OnPlayerExit.AddListener(() => UIManager.instance.HideHelpKeyPanel());
    }

    protected override void SetTaskObject(GameObject interactable)
    {

        GameObject interactableZone = interactable.transform.parent.gameObject;
        

        gadget.listObjects.Remove(interactable);
        base.SetTaskObject(interactable);

        StartCoroutine(CheckZone(interactableZone));
        //CheckZone(interactableZone);
        
        
    }

    IEnumerator CheckZone(GameObject interactableZone)
    //void CheckZone(GameObject interactableZone)
    {

        yield return null;

        if (interactableZone.transform.childCount <= 0)
        {
            UpdateCompassObjects(interactableZone);
            Destroy(interactableZone);
        }


    }


}
