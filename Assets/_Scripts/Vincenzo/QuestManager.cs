using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    [SerializeField]
    public List<Quest> quests = new List<Quest>();
    public GameObject currentQuest;

    private void Awake()
    {
        foreach(Quest quest in quests)
        {
            if(quest.curresntState == Quest.QuestState.ENABLED)
            {
                currentQuest = quest.gameObject;
                break;
            }
        }
    }

}
