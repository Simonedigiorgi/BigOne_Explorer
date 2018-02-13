using Invector.CharacterController;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GadgetManager : MonoBehaviour {

    /*[Header("Equipaggiamento")]
    public bool isHelmet;
    public bool isBackpack;

    [Header("Gadget")]
    public bool isTorch;                                                // Hai la torcia
    public bool isCompass;                                              // Hai il compasso
    public bool isPickaxe;                                              // Hai il piccone
    public bool isScanner;                                              // Hai lo scanner
    public bool isAuger;                                                // Hai la trivella
    public bool isCamera;                                               // Hai la fotocamera
    public bool isJetPack;                                              // Hai il Jetpack
    public bool isGeiger;                                               // Hai il Geiger*/

    public enum GadgetType
    {
        HELMET,
        BACKPACK,
        TORCH,
        COMPASS,
        PICKAXE,
        SCANNER,
        //AUGER,
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
