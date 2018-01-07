using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {
    
    public List<Quest> quests = new List<Quest>();
    public Quest currentQuest;



    private void Awake()
    {

        DontDestroyOnLoad(this);

        for (int i = 0; i < this.transform.childCount; i++)
        {
            Quest quest = this.transform.GetChild(i).gameObject.GetComponent<Quest>();
            quests.Add(quest);
            if (quest.currentState == Quest.QuestState.ENABLED)
            {
                currentQuest = quest;
            }
        }

    }


    /*[SerializeField]
    public List<Quest> quests = new List<Quest>();
    public Quest currentQuest;

    GameObject questsObject;
    GameObject hudDialogues;
    GameObject hudTarget;
    GameObject compass;
    string questTargetText;

    private void Awake()
    {

        DontDestroyOnLoad(this);

        hudTarget = FindObjectOfType<vHUDController>().transform.GetChild(10).gameObject;
        hudDialogues = FindObjectOfType<vHUDController>().transform.GetChild(11).gameObject;
        questsObject = FindObjectOfType<QuestManager>().gameObject;
        compass = FindObjectOfType<CompassLocation>().gameObject;

        for(int i = 0; i < questsObject.transform.childCount; i++)
        {
            Quest quest = questsObject.transform.GetChild(i).gameObject.GetComponent<Quest>();
            quests.Add(quest);
            if(quest.currentState == Quest.QuestState.ENABLED)
            {
                currentQuest = quest;
            }
        }

        questTargetText = "Parla con " + currentQuest.npcAssociated.name;
        hudTarget.GetComponent<Text>().text = questTargetText;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentQuest.currentState == Quest.QuestState.ACTIVING)
        {
            SwitchQuestDialogue();
        }
    }

    public IEnumerator ActivateDialogQuest()
    {

        yield return StartCoroutine(ShowDialogues());
        currentQuest.currentState = Quest.QuestState.ACTIVING;

    }

    public void SwitchQuestDialogue()
    {
        currentQuest.currentDialogue++;

        if (currentQuest.currentDialogue < currentQuest.dialogue.Length)
            hudDialogues.transform.GetChild(0).GetComponent<Text>().text = currentQuest.dialogue[currentQuest.currentDialogue];
        else
            ActivateQuest();


        
    }

    IEnumerator ShowDialogues()
    {
        hudDialogues.gameObject.SetActive(true);
        hudDialogues.transform.GetChild(0).GetComponent<Text>().text = currentQuest.dialogue[currentQuest.currentDialogue];
        yield return null;
    }

    public void ActivateQuest()
    {
        hudDialogues.gameObject.SetActive(false);
        questTargetText = currentQuest.questName + "\n" + currentQuest.questTag + ": " 
                                      + (currentQuest.actionsNumber - currentQuest.actions.Count) + "/" + currentQuest.actionsNumber;
        hudTarget.GetComponent<Text>().text = questTargetText;
        currentQuest.currentState = Quest.QuestState.ACTIVED;

        if(currentQuest.actions.Count > 0)
        {
            var actionContainer = currentQuest.actions[0].transform.parent;
            compass.GetComponent<CompassLocation>().ChangeTargetMission(actionContainer.transform);
        }
        

        foreach (GameObject action in currentQuest.actions)
        {
            action.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void CheckQuestState(GameObject action)
    {
        
        currentQuest.actions.Remove(action);
        action.SetActive(false);

        if(currentQuest.actions.Count == 0)
        {
            CompleteQuest();
        }
        else
        {
            questTargetText = currentQuest.questName + "\n" + currentQuest.questTag + ": "
                              + (currentQuest.actionsNumber - currentQuest.actions.Count) + "/" + currentQuest.actionsNumber;
            hudTarget.GetComponent<Text>().text = questTargetText;
        }
    }

    public void CompleteQuest()
    {
        currentQuest.currentState = Quest.QuestState.COMPLETED;
        int priority = (currentQuest.priority) + 1;
        currentQuest = quests[priority];
        currentQuest.currentState = Quest.QuestState.ENABLED;
        if(currentQuest.npcAssociated != null)
        {
            compass.GetComponent<CompassLocation>().ChangeTargetMission(currentQuest.npcAssociated.transform);
        }
        questTargetText = "Parla con " + currentQuest.npcAssociated.name;
        hudTarget.GetComponent<Text>().text = questTargetText;

        //SceneManager.LoadScene("_Main_Alessandro");

    }*/

}
