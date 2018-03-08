using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Codex : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetGadgetInfo(GadgetManager.GadgetType type)
    {
        Gadget gadget = GameManager.instance.gadgetManager.GetGadgetByType(type);
        this.GetComponentInChildren<Text>().text = gadget.description.ToString();
        //this.GetComponentInChildren<Image>().sprite = gadget.image;
    }
}
