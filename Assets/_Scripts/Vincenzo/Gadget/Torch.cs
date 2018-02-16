using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Gadget {

    Light torch;
	public AudioClip clip;
	public AudioSource tempSource;

    public override void SetGadget()
    {
        base.SetGadget();
        UseGadget();
    }

    protected override void UseGadget()
    {
        if (this.isEquipped)
        {
			tempSource.PlayOneShot (clip);
            GetComponent<Light>().enabled = true;
        }
        else
        {
			tempSource.PlayOneShot (clip);
            GetComponent<Light>().enabled = false;
        }
    }
    

}
