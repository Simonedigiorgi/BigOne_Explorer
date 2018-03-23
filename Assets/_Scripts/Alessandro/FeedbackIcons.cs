using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackIcons : MonoBehaviour
{
    private Animator anim;
    private bool isOpen;

    public Torch torchScript;
    public Scanner scannerScript;
    public Geiger geigerScript;
    public JetPack jetpackScript;

    public Image torchImage;
    public Image scannerImage;
    public Image geigerImage;
    public Image jetpackImage;

    void Start ()
    {
        anim = GetComponent<Animator>();
        isOpen = false;
    }

    void Gets()
    {
        torchScript = transform.root.gameObject.GetComponentInChildren<Torch>();
        scannerScript = transform.root.gameObject.GetComponentInChildren<Scanner>();
        geigerScript = transform.root.gameObject.GetComponentInChildren<Geiger>();
        jetpackScript = transform.root.gameObject.GetComponentInChildren<JetPack>();

        torchImage = GetComponentInChildren<Image>();
        scannerImage = GetComponentInChildren<Image>();
        geigerImage = GetComponentInChildren<Image>();
        jetpackImage = GetComponentInChildren<Image>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
            anim.SetBool("isOpen", isOpen);
        }

        if (torchScript.isEnabled)
        {
            torchImage.IsActive = true;
        }

        if (scannerScript.isEnabled)
        {
            scannerImage.isActive = true;
        }

        if (geigerScript.isEnabled)
        {
            geigerImage.isActive = true;
        }

        if (jetpackScript.isEnabled)
        {
            jetpackImage.isActive = true;
        }
    }
}
