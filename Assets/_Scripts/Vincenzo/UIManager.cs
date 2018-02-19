using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{

    public GameObject dialoguePanel;
    public GameObject targetText;
    public GameObject changeScenePanel;
    public GameObject helpKeyPanel;

    private static UIManager _instance;
    public static UIManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
                //Tell unity not to destroy this object when loading a new scene
                //DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    public void ShowDialoguePanel()
    {
        this.dialoguePanel.GetComponentInChildren<Text>().text = "";
        this.dialoguePanel.SetActive(true);
        //dialoguePanel.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.8f);
    }

    public void HideDialoguePanel()
    {
        //dialoguePanel.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
        this.dialoguePanel.SetActive(false);
        this.dialoguePanel.GetComponentInChildren<Text>().text = "";

    }

    public void SetTartgetText(string targetText)
    {
        this.targetText.GetComponent<Text>().text = targetText;
    }

    public void ShowScenePanel()
    {
        this.changeScenePanel.gameObject.SetActive(true);
    }

    public void HideScenePanel()
    {
        this.changeScenePanel.gameObject.SetActive(false);
    }

    public void ShowHelpKeyPanel()
    {
        if (Input.GetJoystickNames().Length > 0)
        {
            helpKeyPanel.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            helpKeyPanel.transform.GetChild(0).gameObject.SetActive(true);
        }
        helpKeyPanel.gameObject.SetActive(true);
    }

    public void HideHelpKeyPanel()
    {
        helpKeyPanel.transform.GetChild(0).gameObject.SetActive(false);
        helpKeyPanel.transform.GetChild(1).gameObject.SetActive(false);
        helpKeyPanel.gameObject.SetActive(true);
    }

}
