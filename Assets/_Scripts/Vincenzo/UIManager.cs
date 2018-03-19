using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private void Start()
    {
        //OverlineTargetText();
    }

    public void ShowDialoguePanel()
    {
        this.dialoguePanel.GetComponentInChildren<Text>().text = "";
        this.dialoguePanel.SetActive(true);
    }

    public void HideDialoguePanel()
    {
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

        vThirdPersonController.instance.animator.CrossFadeInFixedTime("Death", 0.1f);

        fadeImage.GetComponent<Image>().DOFade(1, 3);
        yield return new WaitForSeconds(3.9f);
        //fadeImage.GetComponent<Image>().DOFade(0, 0);
        //fadeImage.enabled = false;

        GenericSettings genericSettings = vThirdPersonController.instance.gameObject.GetComponent<GenericSettings>();
        genericSettings.UnlockPlayer();

        var spawnPointFinderObj = new GameObject("spawnPointFinder");
        var spawnPointFinder = spawnPointFinderObj.AddComponent<vFindSpawnPoint>();

        spawnPointFinder.AlighObjetToSpawnPoint(vThirdPersonController.instance.gameObject, Invector.vGameController.instance.spawnPoint.name);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        yield return new WaitForSeconds(1f);

        genericSettings.IsDead = false;

    }

    public Sequence OverlineTargetText()
    {
        Sequence animationSequence = DOTween.Sequence();

        if (QuestManager.instance.CurrentTargetObjects != null && QuestManager.instance.CurrentTargetObjects != "")
        {
            animationSequence.Append(targetText.transform.parent.GetChild(2).GetComponent<Text>().DOFade(0, 1));
            animationSequence.Append(targetText.transform.parent.GetChild(2).GetComponent<Text>().DOText("", 0));
            animationSequence.Join(targetText.transform.parent.GetChild(2).GetComponent<Text>().DOFade(1, 0));
            QuestManager.instance.CurrentTargetObjects = "";
        }

        animationSequence.Append(targetText.transform.GetChild(0).GetComponent<Image>().DOFillAmount(1, 1.5f));
        animationSequence.Append(targetText.transform.parent.GetChild(1).GetComponent<Image>().DOFillAmount(1, .5f));

        return animationSequence;

    }

    public Sequence FadeOutTargetText()
    {
        Sequence animationSequence = DOTween.Sequence();

        animationSequence.Append(targetText.transform.GetChild(0).GetComponent<Image>().DOFade(0, 1f));
        animationSequence.Join(targetText.transform.parent.GetChild(1).GetComponent<Image>().DOFade(0, 1f));
        animationSequence.Join(targetText.GetComponent<Text>().DOFade(0, 1f));

        animationSequence.Append(targetText.transform.GetChild(0).GetComponent<Image>().DOFillAmount(0, 0));
        animationSequence.Append(targetText.transform.parent.GetChild(1).GetComponent<Image>().DOFillAmount(0, 0));

        animationSequence.Append(targetText.GetComponent<Text>().DOText("", 0));
        animationSequence.Join(targetText.GetComponent<Text>().DOFade(1, 1f));
        animationSequence.Join(targetText.transform.GetChild(0).GetComponent<Image>().DOFade(1, 0));
        animationSequence.Join(targetText.transform.parent.GetChild(1).GetComponent<Image>().DOFade(1, 0));

        return animationSequence;
    }

    public IEnumerator WriteTargetText()
    {
        Sequence animationSequence = DOTween.Sequence();

        animationSequence.Append(targetText.GetComponent<Text>().DOText(QuestManager.instance.CurrentTarget, 2));

        yield return animationSequence.WaitForCompletion();

        if (QuestManager.instance.CurrentTargetObjects != null && QuestManager.instance.CurrentTargetObjects != "")
        {
            animationSequence.Append(targetText.transform.parent.GetChild(2).GetComponent<Text>().DOText(QuestManager.instance.CurrentTargetObjects, 2));
        }
    }

    public void ChangeTargetObjectText()
    {
        targetText.transform.parent.GetChild(2).GetComponent<Text>().text = QuestManager.instance.CurrentTargetObjects;
    }

}
