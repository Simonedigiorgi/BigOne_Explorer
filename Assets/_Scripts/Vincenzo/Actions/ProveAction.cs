using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProveAction : vTriggerGenericAction {

    protected override void Start()
    {

        base.Start();

        OnDoAction.AddListener(() => GetProve());
    }

    
    public void GetProve()
    {
        if(QuestManager.instance.currentQuest.taskActived.GetComponent<TaskInteract>())
        {
            if (QuestManager.instance.currentQuest.taskActived.GetComponent<TaskInteract>().isDestroyable)
            {
                //Destroy(this.transform.parent.gameObject);
                this.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                this.transform.parent.GetChild(1).gameObject.SetActive(true);
                this.gameObject.SetActive(false);
                //Destroy(this.gameObject);
            }
                

        }
		
    }

}
