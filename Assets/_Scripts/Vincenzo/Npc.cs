using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour {

    /*[SerializeField]
    public GameObject[] targets;*/
    bool playerTriggered;
    QuestManager questManager;

	// Use this for initialization
	void Start ()
    {
        questManager = FindObjectOfType<QuestManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.E) && questManager.currentQuest.currentState == Quest.QuestState.ENABLED && playerTriggered)
        {
            StartCoroutine(questManager.ActivateDialogQuest());
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !playerTriggered)
        {
            playerTriggered = true;
            this.transform.parent.GetChild(2).gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && playerTriggered && (questManager.currentQuest.currentState == Quest.QuestState.ACTIVED))
        {
            this.transform.parent.GetChild(2).gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && playerTriggered)
        {
            playerTriggered = false;
        }
    }


}
