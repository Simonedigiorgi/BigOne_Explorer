using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public enum DoorBehaviour { Outside, Inside }
    public DoorBehaviour doorBehaviour;

    private AudioSource source;

    public AudioClip open;
    public AudioClip close;

    public Animator doorDown;
    public Animator doorUp;

    public void OnTriggerEnter(Collider other)
    {
        //source.PlayOneShot(close); // TOGLIERE IL COMMENTO
        if (doorBehaviour == DoorBehaviour.Outside)
        {
            if (other.gameObject.tag == "Player" &&
                GameManager.instance.gadgetManager.GetGadgetByType(GadgetManager.GadgetType.HELMET).isEnabled &&
                GameManager.instance.gadgetManager.GetGadgetByType(GadgetManager.GadgetType.BACKPACK).isEnabled) 
            {
                doorDown.SetTrigger("DownOpen");
                doorUp.SetTrigger("UpOpen");
            }
        }

        if (doorBehaviour == DoorBehaviour.Inside)
        {
            if (other.gameObject.tag == "Player")
            {
                doorDown.SetTrigger("DownOpen");
                doorUp.SetTrigger("UpOpen");
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //source.PlayOneShot(open); // TOGLIERE IL COMMENTO
        if (doorBehaviour == DoorBehaviour.Outside || doorBehaviour == DoorBehaviour.Inside)
        {
            if (other.gameObject.tag == "Player")
            {
                doorDown.SetTrigger("DownClose");
                doorUp.SetTrigger("UpClose");      
            }
        }
    }
}
