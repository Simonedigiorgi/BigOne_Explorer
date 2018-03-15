using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{

    public GameObject dialoguePanel;
    public GameObject targetText;
    public GameObject changeScenePanel;
    public GameObject helpKeyPanel;

    public Image fadeImage;

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

    /*private void Update()
    {
        if(vThirdPersonController.instance.currentHealth == 0)
        {
            StartCoroutine(FadeDeath());
        }
    }*/

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

    public IEnumerator FadeDeath()
    {
        fadeImage.enabled = true;
        vThirdPersonController.instance.gameObject.GetComponent<GenericSettings>().LockPlayer();
        yield return new WaitForSeconds(0f);

        fadeImage.GetComponent<Image>().DOFade(1, 3);
        yield return new WaitForSeconds(3.95f);
        /*fadeImage.GetComponent<Image>().DOFade(0, 1);
        yield return new WaitForSeconds(2);*/
        fadeImage.enabled = false;
        vThirdPersonController.instance.gameObject.GetComponent<GenericSettings>().UnlockPlayer();
    }

}
