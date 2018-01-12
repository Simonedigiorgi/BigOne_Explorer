using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum InteractableType
{
    EQUIPMENT,
    PANEL,
    MINERAL,
    TUBE,
    PROBE
}

public static class Database
{

    /*public static List<DataEquipment> equipments = new List<DataEquipment>();
    public static List<DataPanel> panels = new List<DataPanel>();
    public static List<DataMineral> minerals = new List<DataMineral>();
    public static List<DataTube> tubes = new List<DataTube>();
    public static List<DataProbe> probes = new List<DataProbe>();*/

    public static List<InteractableObject> interactableObjects = new List<InteractableObject>();

    public static List<DataGadget> gadgets = new List<DataGadget>();
    public static List<DataScene> scenes = new List<DataScene>();
    public static List<DataQuest> quests = new List<DataQuest>();

    public static DataQuest currentQuest;
    public static string currentScene;


    [Serializable]
    public class InteractableObject
    {
        public InteractableType type;
        public string interactableName;
        public bool isInteractable;
    }


    [Serializable]
    public class DataEquipment: InteractableObject
    {
        
    }

    [Serializable]
    public class DataPanel : InteractableObject
    {
        
    }

    [Serializable]
    public class DataMineral : InteractableObject
    {
        
    }

    [Serializable]
    public class DataTube : InteractableObject
    {
        
    }

    [Serializable]
    public class DataProbe : InteractableObject
    {
        
    }

    [Serializable]
    public class DataGadget
    {
        public string gadgetName;
        public bool isActive;
    }

    [Serializable]
    public class DataScene
    {
        public string sceneName;
        public bool isUnlocked;
    }

    [Serializable]
    public class DataQuest
    {

        public DataQuest(Quest.QuestState pState, string pName, int pPriority)
        {
            this.currentState = pState;
            this.questName = pName;
            this.questPriority = pPriority;
        }

        public Quest.QuestState currentState;
        public string questName;
        public List<DataTask> tasks = new List<DataTask>();
        public DataTask activedTask;
        public int questPriority;
    }

    [Serializable]
    public class DataTask
    {
        public DataTask(Task.TaskState pState, string pName, int pPriority)
        {
            this.currentState = pState;
            this.taskName = pName;
            this.taskPriority = pPriority;
        }

        public Task.TaskState currentState;
        public string taskName;
        public int taskPriority;
    }

}
