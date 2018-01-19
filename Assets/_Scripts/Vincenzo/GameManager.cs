using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    QuestManager questManager;
    public static bool newGame = true;
    

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

        if(newGame)
            //StartCoroutine(questManager.InitQuests());
            questManager.InitQuests();
    }

    // Use this for initialization
    void Start () {
		
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
        QuestManager.CheckQuest();
        Database.currentScene = scene.name;
        SetObjectScene(scene);
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
}
