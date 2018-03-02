using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        base.SetGadget();
        UseGadget();
    }

    protected override void UseGadget()
    {
        if (this.isEquipped)
        {
            tempSource.PlayOneShot(clip);
            lights[0].enabled = true;
            lights[1].enabled = true;
        }
		else if(this.isEnabled == true)
        {
			tempSource.PlayOneShot (clip);
            lights[0].enabled = false;
            lights[1].enabled = false;
        }
    }
}
