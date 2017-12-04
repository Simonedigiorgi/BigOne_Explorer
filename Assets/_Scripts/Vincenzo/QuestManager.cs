using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {

    [SerializeField]
    public List<Quest> quests = new List<Quest>();
    public Quest currentQuest;
    GameObject questsObject;

    GameObject hudDialogues;

    private void Awake()
    {

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
        if (Input.GetKeyDown(KeyCode.E) && currentQuest.currentState == Quest.QuestState.ACTIVED)
        {
            ActivateQuest();
        }
    }

    public void ActivateQuest()
    {
        hudDialogues.gameObject.SetActive(true);
        hudDialogues.transform.GetChild(0).GetComponent<Text>().text = currentQuest.dialogue[0];
    }

}
