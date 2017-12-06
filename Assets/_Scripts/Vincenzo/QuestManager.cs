using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {

    [SerializeField]
    public List<Quest> quests = new List<Quest>();
    public Quest currentQuest;

    int currentDialogue = 0;
    GameObject questsObject;
    GameObject hudDialogues;

    private void Awake()
    {

        print("Awake");

        DontDestroyOnLoad(this);

        hudDialogues = FindObjectOfType<vHUDController>().transform.GetChild(10).gameObject;
        questsObject = FindObjectOfType<QuestManager>().gameObject;

        for(int i = 0; i < questsObject.transform.childCount; i++)
        {
            Quest quest = questsObject.transform.GetChild(i).gameObject.GetComponent<Quest>();
            quests.Add(quest);
            if(quest.currentState == Quest.QuestState.ENABLED)
            {
                currentQuest = quest;
            }
        }

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
        currentDialogue++;

        if (currentDialogue < currentQuest.dialogue.Length)
            hudDialogues.transform.GetChild(0).GetComponent<Text>().text = currentQuest.dialogue[currentDialogue];
        else
            ActivateQuest();


        
    }

    IEnumerator ShowDialogues()
    {
        hudDialogues.gameObject.SetActive(true);
        hudDialogues.transform.GetChild(0).GetComponent<Text>().text = currentQuest.dialogue[currentDialogue];
        yield return null;
    }

    public void ActivateQuest()
    {
        hudDialogues.gameObject.SetActive(false);
        currentQuest.currentState = Quest.QuestState.ACTIVED;
        foreach (GameObject action in currentQuest.actions)
        {
            action.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void CompleteQuest()
    {
        currentQuest.currentState = Quest.QuestState.COMPLETED;
        int priority = (currentQuest.priority) + 1;
        currentQuest = quests[priority];
        currentQuest.currentState = Quest.QuestState.ENABLED;

        //SceneManager.LoadScene("_Main_Alessandro");

    }

}
