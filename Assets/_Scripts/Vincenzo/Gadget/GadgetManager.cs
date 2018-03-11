using Invector.CharacterController;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GadgetManager : MonoBehaviour {

    public enum GadgetType
    {
        HELMET,
        BACKPACK,
        TORCH,
        COMPASS,
        PICKAXE,
        SCANNER,
        CAMERA,
        JETPACK,
        GEIGER
    }

    public List<Gadget> gadgets;

    /*public void SetGadgets()
    {
        foreach(Database.DataGadget dataGadget in Database.gadgets)
        {
            GadgetType gadget = (GadgetType)Enum.Parse(typeof(GadgetType), dataGadget.gadgetName);
            ActivateGadget(gadget, dataGadget.isActive);
        }
    }*/

    public void InitGadgets()
    {
        Gadget[] gadgetList = GetComponentsInChildren<Gadget>(true);

        for(int i = 0; i < gadgetList.Length; i++)
        {
            gadgets.Add(gadgetList[i]);
            Database.DataGadget dataGadget = new Database.DataGadget(Enum.GetName(typeof(GadgetType), gadgetList[i].gadgetType), false);
            Database.gadgets.Add(dataGadget);
        }

        //PrintGadget();
    }

    public List<Gadget> GetEnabledGadgets()
    {
        List<Gadget> enabledGadgets = new List<Gadget>();

        foreach(Gadget gadget in gadgets)
        {
            if(gadget.isEnabled)
            {
                gadgets.Add(gadget);
            }
        }

        return enabledGadgets;
    }

    public Gadget GetGadgetByType(GadgetType type)
    {
        Gadget gadgetToReturn = this.gadgets.Find(x => x.gadgetType == type);
        return gadgetToReturn;
    }

    // Da cancellare
    public void PrintGadget()
    {
        foreach(Database.DataGadget g in Database.gadgets)
        {
            print(g.gadgetName + ": " + g.isActive);
        }
    }

}
