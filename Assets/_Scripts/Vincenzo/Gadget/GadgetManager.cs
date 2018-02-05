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

    void Start () {



        // EQUIPAGGIAMENTO

        /*if(isHelmet == true && isBackpack == false)
        {
            Debug.Log("Hai bisogno dello Zaino");
        }

        if (isHelmet == false && isBackpack == true)
        {
            Debug.Log("Hai bisogno del Casco");
        }

        // GADGETS

        if (isJetPack == true)
        {
            Debug.Log("Se JetPack è true aggiungi 1 a Multijump");
        }*/
    }
	
	void Update () {

        /*if(Input.GetKeyDown(KeyCode.P))
        {
            foreach (Gadget g in GetComponentsInChildren<Gadget>(true))
            {
                print(g.gadgetType);
                if(g.gadgetType == GadgetType.HELMET)
                {
                    print("Cipolla");
                }
            }
        }

        // EQUIPAGGIAMENTO

       /* if (isHelmet == false && isBackpack == true)
        {
            Debug.Log("Apri la porta");
        }

        // GADGETS

        if (isTorch == true)
        {
            Debug.Log("Se premi T e isTorch è true avvia il metodo Torch");
        }

        if (isCompass == true)
        {
            Debug.Log("Se premi _ e isCompass è true avvia il metodo Compass");
        }

        if (isPickaxe == true)
        {
            Debug.Log("Se premi _ e isPickaxe è true avvia il metodo Pickaxe");
        }

        if (isScanner == true)
        {
            Debug.Log("Se premi _ e isScanner è true avvia il metodo Scanner");
        }

        if (isAuger == true)
        {
            Debug.Log("Se premi _ e isAuger è true avvia il metodo Auger");
        }

        if (isGeiger == true)
        {
            Debug.Log("Se premi _ e isGeiger è true avvia il metodo Geiger");
        }*/
    }

    /*public void Torch()
    {

    }

    public void Compass()
    {

    }

    public void Pickaxe()
    {

    }

    public void Scanner()
    {

    }

    public void Auger()
    {

    }

    public void Camera()
    {

    }

    public void Jetpack()
    {

    }

    public void Geiger()
    {

    }*/

    /*public void ActivateGadget(GadgetType gadgetType, bool active)
    {

        switch(gadgetType)
        {
            case GadgetType.HELMET:
                isHelmet = active;
                break;
            case GadgetType.BACKPACK:
                isBackpack = active;
                break;
            case GadgetType.TORCH:
                isTorch = active;
            break;
            case GadgetType.COMPASS:
                isCompass = active;
            break;
            case GadgetType.PICKAXE:
                isPickaxe = active;
            break;
            case GadgetType.SCANNER:
                isScanner = active;
            break;
            case GadgetType.CAMERA:
                isCamera = active;
            break;
            case GadgetType.AUGER:
                isAuger = active;
            break;
            case GadgetType.JETPACK:
                isJetPack = active;
            break;
            case GadgetType.GEIGER:
                isGeiger = active;
            break;

        }

    }

    public void InitGadgets()
    {
        var gadget = Enum.GetNames(typeof(GadgetType));
        for (int i = 0; i < gadget.Length - 1; i++)
        {
            Database.DataGadget dataGadget = new Database.DataGadget(gadget[i], false);
            Database.gadgets.Add(dataGadget);
        }
    }

    public void SetGadgets()
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

    public void PrintGadget()
    {
        foreach(Database.DataGadget g in Database.gadgets)
        {
            print(g.gadgetName + ": " + g.isActive);
        }
    }

}
