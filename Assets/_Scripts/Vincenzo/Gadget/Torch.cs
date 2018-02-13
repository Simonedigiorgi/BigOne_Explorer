using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Gadget {

    Light torch;

    public override void SetGadget()
    {
        base.SetGadget();
        UseGadget();
    }

    protected override void UseGadget()
    {
        if (this.isEquipped)
        {
            GetComponent<Light>().enabled = true;
        }
        else
        {
            GetComponent<Light>().enabled = false;
        }
    }
    

}
