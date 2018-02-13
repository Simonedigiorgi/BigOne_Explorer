using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gadget : MonoBehaviour {

    public GadgetManager.GadgetType gadgetType;
    public bool isEnabled;
    public bool isEquipped;
    [Header("Lista di oggetti da cercare nella scena")]
    public List<Transform> listObjects;

    public virtual void EnableGadget()
    {
        this.isEnabled = true;
    }

    public virtual void SetGadget()
    {
        if(this.isEnabled)
        {
            this.isEquipped = !this.isEquipped;
        }
            
    }

    protected virtual void UseGadget()
    {

    }

}
