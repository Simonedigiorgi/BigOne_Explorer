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
    public float yOffsetHelpKey;

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

    private void Update()
    {
        if(helpKeyPanel.gameObject.activeSelf)
        {
            Vector3 relativePos = vThirdPersonCamera.instance.transform.position;
            relativePos.y = helpKeyPanel.transform.position.y;
            helpKeyPanel.transform.LookAt(relativePos);
        }
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

    /*public void ShowHelpKeyPanel()
    {
        helpKeyPanel.gameObject.SetActive(true);
        if (Input.GetJoystickNames().Length > 0)
        {
            helpKeyPanel.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            helpKeyPanel.transform.GetChild(0).GetComponent<Image>().DOFade(1, 0.4f);
            helpKeyPanel.transform.GetChild(0).GetComponent<RectTransform>().DOScale(2f, 0.6f);
            helpKeyPanel.transform.GetChild(0).GetComponent<RectTransform>().DOLocalMoveY(16, 0.4f);
        }
        
    }*/

    public void ShowCanvasHelpKey(Transform triggerObjectTransform)
    {
        helpKeyPanel.gameObject.SetActive(true);
        /*helpKeyPanel.transform.position = new Vector3(triggerObjectTransform.position.x,
            triggerObjectTransform.position.y + triggerObjectTransform.gameObject.GetComponent<Collider>().bounds.size.y + ((helpKeyPanel.GetComponent<RectTransform>().rect.height / 2) / 100), 
            triggerObjectTransform.position.z);*/
        if(triggerObjectTransform.gameObject.CompareTag("Panels") || triggerObjectTransform.gameObject.CompareTag("Wall"))
        {
            helpKeyPanel.transform.position = new Vector3(vThirdPersonController.instance.transform.position.x,
            vThirdPersonController.instance.transform.position.y + vThirdPersonController.instance.transform.GetComponent<Collider>().bounds.size.y + yOffsetHelpKey,
            vThirdPersonController.instance.transform.position.z);
        }
        else
        {
            helpKeyPanel.transform.position = new Vector3(triggerObjectTransform.position.x,
            triggerObjectTransform.position.y + triggerObjectTransform.gameObject.GetComponent<Collider>().bounds.size.y,
            triggerObjectTransform.position.z);
        }
        

        if (Input.GetJoystickNames().Length > 0)
        {
            helpKeyPanel.transform.GetChild(1).GetComponent<Image>().DOFade(1, 0.4f);
            helpKeyPanel.transform.GetChild(1).GetComponent<RectTransform>().DOScale(0.8f, 0.6f);
            helpKeyPanel.transform.GetChild(1).GetComponent<RectTransform>().DOLocalMoveY(16, 0.4f);
        }
        else
        {
            helpKeyPanel.transform.GetChild(0).GetComponent<Image>().DOFade(1, 0.4f);
            helpKeyPanel.transform.GetChild(0).GetComponent<RectTransform>().DOScale(1f, 0.6f);
            helpKeyPanel.transform.GetChild(0).GetComponent<RectTransform>().DOLocalMoveY(16, 0.4f);
        }
    }

    public void HideHelpKey()
    {
        Sequence sequenceAnimation = DOTween.Sequence();

        if (Input.GetJoystickNames().Length > 0)
        {
            sequenceAnimation.Append(helpKeyPanel.transform.GetChild(1).GetComponent<Image>().DOFade(0, 0.4f));
            sequenceAnimation.Join(helpKeyPanel.transform.GetChild(1).GetComponent<RectTransform>().DOScale(0.6f, 0.4f));
            sequenceAnimation.Join(helpKeyPanel.transform.GetChild(1).GetComponent<RectTransform>().DOLocalMoveY(-16, 0.4f));
        }
        else
        {
            sequenceAnimation.Append(helpKeyPanel.transform.GetChild(0).GetComponent<Image>().DOFade(0, 0.4f));
            sequenceAnimation.Join(helpKeyPanel.transform.GetChild(0).GetComponent<RectTransform>().DOScale(0.6f, 0.4f));
            sequenceAnimation.Join(helpKeyPanel.transform.GetChild(0).GetComponent<RectTransform>().DOLocalMoveY(-16, 0.4f));
        }

        StartCoroutine(HideHelpKeyPanel(sequenceAnimation));
    }

    IEnumerator HideHelpKeyPanel(Sequence sequenceAnimation)
    {
        yield return sequenceAnimation.WaitForCompletion();
        helpKeyPanel.gameObject.SetActive(false);
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
