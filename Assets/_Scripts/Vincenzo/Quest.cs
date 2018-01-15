using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{

    public enum QuestState
    {
        DISABLED,
        ENABLED,
        COMPLETED
    }

    public QuestState currentState;
    public string questName;
    public int questPriority;
    public Task taskActived;

    public List<Task> questTasks = new List<Task>();

    private void Awake()
    {
        /*questTasks = new List<Task>();
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            questTasks.Add(this.gameObject.transform.GetChild(i).gameObject.GetComponent<Task>());
        }

        if(this.currentState == QuestState.ENABLED)
        {
            taskActived = questTasks.Find(x => x.currentState == Task.TaskState.ENABLED);
        }*/


    }

    //public IEnumerator InitQuest(Database.DataQuest quest)
    public void InitQuest(Database.DataQuest quest)
    {    
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {

            Task task = this.gameObject.transform.GetChild(i).gameObject.GetComponent<Task>();
            questTasks.Add(task);

            Database.DataTask dataTask = new Database.DataTask(task.currentState, task.taskName, task.taskPriority);
            quest.tasks.Add(dataTask);

            if (task.currentState == Task.TaskState.ENABLED)
            {
                taskActived = task;
                quest.activedTask = dataTask;
            }
            
        }

        //yield return null;
    }

    public IEnumerator SetQuest(Database.DataQuest quest)
    {
        foreach(Database.DataTask dataTask in quest.tasks)
        {
            Task task = this.gameObject.transform.GetChild(dataTask.taskPriority).gameObject.GetComponent<Task>();
            task.currentState = dataTask.currentState;
            questTasks.Add(task);

            if (dataTask.currentState == Task.TaskState.ENABLED)
            {
                taskActived = questTasks[task.taskPriority];
            }
        }

        yield return null;
    }

    public void EnableQuest()
    {
        this.currentState = QuestState.ENABLED;
        Database.quests[Database.currentQuest.questPriority].currentState = QuestState.ENABLED;
    }

    public void CompleteQuest()
    {
        this.currentState = QuestState.COMPLETED;

        Database.quests[Database.currentQuest.questPriority].currentState = QuestState.COMPLETED;

        this.transform.parent.GetComponent<QuestManager>().SwitchToNextQuest();
    }

    public void SwitchToNextTask()
    {
        if (taskActived.taskPriority < questTasks.Count-1)
        {
            int tempPriority = taskActived.taskPriority;
            tempPriority++;

            taskActived = questTasks[tempPriority];
            Database.currentQuest.activedTask = Database.quests[Database.currentQuest.questPriority].tasks[tempPriority];

            taskActived.EnableTask();

        }
        else
        {
            CompleteQuest();
        }
    }





























    /*public enum QuestState
    {
        DISABLED,
        ENABLED,
        ACTIVING,
        ACTIVED,
        COMPLETED
    }

	public string questName;
    public QuestState currentState;
    public GameObject npcAssociated;
    public int priority;
    //public GameObject[] actions;
    public List<GameObject> actions;

    [HideInInspector]
    public int actionsNumber;

    public string questTag;

    [Header("Dialogues for this quest")]
    [TextArea]
    public string[] dialogue;

    [HideInInspector]
    public int currentDialogue = 0;

    void Start()
    {
        var tempActions = GameObject.FindGameObjectsWithTag(questTag);
        foreach(GameObject action in tempActions)
        {
            actions.Add(action);
        }
        actionsNumber = actions.Count;

        //print(actionsNumber);

    }*/

}
