using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torch : Gadget {

    Light [] lights;
	public AudioClip clip;
	public AudioSource tempSource;

    private void Start ()
    {
        lights = GetComponentsInChildren<Light>(true);
    }

    public override void SetGadget()
    {
        if (this.isEnabled)
        {
            this.isEquipped = !this.isEquipped;
            UseGadget();
        }
        
    }

    protected override void UseGadget()
    {

        if (this.isEquipped)
        {
            //tempSource.PlayOneShot(clip);
            lights[0].enabled = true;
            lights[1].enabled = true;
        }
        else
        {
            lights[0].enabled = false;
            lights[1].enabled = false;
        }
    }
}
