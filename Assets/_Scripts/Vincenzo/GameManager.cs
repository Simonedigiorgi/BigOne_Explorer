using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public static bool newGame = true;
    public List<string> scenes;

    QuestManager questManager;
    GadgetManager gadgetManager;

    private void Awake()
    {

        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(this);

        questManager = FindObjectOfType<QuestManager>();
        gadgetManager = FindObjectOfType<GadgetManager>();
        scenes = new List<string>();

        if (newGame)
        {
            //StartCoroutine(questManager.InitQuests());
            questManager.InitQuests();
            gadgetManager.InitGadgets();
            this.SetScenes();

        }
            
    }

    // Use this for initialization
    void Start ()
    {

        

        
        
		
	}

    

	/*public IEnumerator InitNewGame()
    {
        yield return StartCoroutine(questManager.InitQuests());
        setGame = true;
    }

    public void InitSavedGame()
    {

    }*/

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        questManager.CheckQuest();
        Database.currentScene = scene.name;
        SetObjectScene(scene);
        //print(questManager.currentTarget);
        /*foreach(Database.InteractableObject o in Database.interactableObjects)
        {
            print(o.type+" - "+o.interactableName+" - "+o.isInteractable);
        }*/
        /*foreach (Database.DataQuest quest in Database.quests)
        {
            print(quest.questName);
            print(quest.currentState);
            foreach (Database.DataTask task in quest.tasks)
            {
                    
                print(task.taskName);
                print(task.currentState);
            }

            print("\n");
        }*/
        
    }

    void SetObjectScene(Scene scene)
    {
        if(Database.interactableObjects.Count > 0 && Database.interactableObjects.Exists(x => x.sceneContainer == scene.name))
        {
            foreach(Database.InteractableObject interactable in Database.interactableObjects)
            {
                if(interactable.sceneContainer == scene.name && !interactable.isInteractable)
                {
                    GameObject interactableToDestroy = GameObject.Find(interactable.interactableName);
                    Destroy(interactableToDestroy);
                }
            }
        }
    }

    void SetScenes()
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string[] containerSceneName = SceneUtility.GetScenePathByBuildIndex(i).Split('/');
            string[] sceneName = containerSceneName[2].Split('.');
            scenes.Add(sceneName[0]);
            bool isUnlocked = false;
            if (i == 0 || i == 1)
            {
                isUnlocked = true;
            }
            Database.DataScene dataScene = new Database.DataScene(sceneName[0], isUnlocked);
            Database.scenes.Add(dataScene);
        }

        /*foreach(Database.DataScene scene in Database.scenes)
        {
            print(scene.sceneName+": "+scene.isUnlocked);
        }*/

    }

    /*public void PrintData()
    {

        print("Ciao");

        foreach (Database.DataQuest quest in Database.quests)
        {
            print(quest.questName);
            print(quest.currentState);
            foreach (Database.DataTask task in quest.tasks)
            {

                print(task.taskName);
                print(task.currentState);
            }

            print("\n");
        }

        foreach(Database.DataScene scene in Database.scenes)
        {
            print(scene.sceneName + ": " + scene.isUnlocked);
        }
    }*/
}
