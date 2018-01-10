using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GadgetManager : MonoBehaviour {

    [Header("Equipaggiamento")]
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
    public bool isGeiger;                                               // Hai il Geiger

    public enum GadgetType
    {
        TORCH,
        COMPASS,
        PICKAXE,
        SCANNER,
        AUGER,
        CAMERA,
        JETPACK,
        GEIGER
    }

	void Start () {

        // EQUIPAGGIAMENTO

        if(isHelmet == true && isBackpack == false)
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
        }
    }
	
	void Update () {

        // EQUIPAGGIAMENTO

        if (isHelmet == false && isBackpack == true)
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
        }
    }

    public void Torch()
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

    }

    public void ActivateGadget(GadgetType gadgetType)
    {

        switch(gadgetType)
        {
            case GadgetType.TORCH:
                isTorch = true;
            break;
            case GadgetType.COMPASS:
                isCompass = true;
            break;
            case GadgetType.PICKAXE:
                isPickaxe = true;
            break;
            case GadgetType.SCANNER:
                isScanner = true;
            break;
            case GadgetType.CAMERA:
                isCamera = true;
            break;
            case GadgetType.AUGER:
                isAuger = true;
            break;
            case GadgetType.JETPACK:
                isJetPack = true;
            break;
            case GadgetType.GEIGER:
                isGeiger = true;
            break;

        }

    }
}
