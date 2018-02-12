using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour {

    private AudioSource source;

    public AudioClip open;
    public AudioClip close;

    private Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") // + AGGIUNGERE CONDIZIONE EQUIPAGGIAMENTO
        {
            //source.PlayOneShot(open); // TOGLIERE IL COMMENTO

            anim.SetBool("LeftOpen", true);
            anim.SetBool("RightOpen", true);

            anim.SetBool("LeftClose", false);
            anim.SetBool("RightClose", false);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") // + AGGIUNGERE CONDIZIONE EQUIPAGGIAMENTO
        {
            //source.PlayOneShot(close); // TOGLIERE IL COMMENTO

            anim.SetBool("LeftOpen", false);
            anim.SetBool("RightOpen", false);

            anim.SetBool("LeftClose", true);
            anim.SetBool("RightClose", true);

        }
    }

}
