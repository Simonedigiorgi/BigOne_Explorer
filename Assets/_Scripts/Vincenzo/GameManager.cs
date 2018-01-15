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
            StartCoroutine(questManager.InitQuests());
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

    }

    void OnEnable()
    {
        if(startedGame)
            SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        if (startedGame)
            SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(!setGame)
        {
            StartCoroutine(InitNewGame());
        }
        /*else
        {
            foreach (Database.DataQuest quest in Database.quests)
            {
                print(quest.questName);
                print(quest.currentState);
                foreach (Database.DataTask task in quest.tasks)
                {
                    print(task.currentState);
                    print(task.taskName);
                }

                print("\n");
            }

            print(Database.currentQuest.questName);
            StartCoroutine(questManager.SetQuests());
        }
    }*/
}
