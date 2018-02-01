using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{

    public GameObject dialoguePanel;
    public GameObject targetText;
    public GameObject ChangeScenePanel;

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



}
