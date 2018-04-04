using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;
using Sirenix.OdinInspector;
using DG.Tweening;

public class SManager : MonoBehaviour {

    private PostProcessingBehaviour behaviour;                                                      // Profilo del Post-Processing (vThirdController)
    private GameObject quest;                                                                       // Cerca il Gameobject "Quest"

    [BoxGroup("PostProcessing Profiles for Gale")] public PostProcessingProfile insideBase;
    [BoxGroup("PostProcessing Profiles for Gale")] public PostProcessingProfile outsideBase;

    [BoxGroup("PostProcessing Profiles for Other Scenes")] public PostProcessingProfile mid;
    [BoxGroup("PostProcessing Profiles for Other Scenes")] public PostProcessingProfile sunset;

    [BoxGroup("Trigger Collider (Gale Crater)")] public BoxCollider outsideTrigger; // Posizione Cratere (X 62, Y 1, Z -280) Rotation (Y -50)
    [BoxGroup("Trigger Collider (Gale Crater)")] public BoxCollider insideTrigger; // Posizione Cratere (x 60, Y 1, Z -278,56) Rotation (Y -50)

    // Scena

    private Text sceneText;
    private Text temperatureText;
    private Text dayText;

    // Sol

    private Image fadeSol;
    private Text solLeft;
    private Text solCenter;
    private bool quest1, quest2, quest3, quest4, quest5, quest6, quest7, quest8;

    // Missions

    private Text missionTitleText;
    private Text descriptionText;
    private bool mission1, mission2, mission3;

    private int temperatureValue;                                                                   

    private bool isGale;                                                                            // Bool per le Animazioni delle Icone
    private bool isValles;                                                                          // Bool per le Animazioni delle Icone
    private bool isNoctis;                                                                          // Bool per le Animazioni delle Icone                                                                
    private bool isOlympus;                                                                         // Bool per le Animazioni delle Icone

    private bool isGaleLoaded;                                                                      // Bool per il cambio Post-Processing

    void Start()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

        behaviour = FindObjectOfType<vThirdPersonCamera>().GetComponent<PostProcessingBehaviour>();
        quest = GameObject.Find("Quests");

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        temperatureValue = Random.Range(-60, 20);

        // GET SCENE INFO

        sceneText = transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        temperatureText = transform.GetChild(0).transform.GetChild(1).GetComponent<Text>();
        dayText = transform.GetChild(0).transform.GetChild(2).GetComponent<Text>();

        // GET SOL INFO

        fadeSol = transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();
        solLeft = transform.GetChild(1).transform.GetChild(1).GetComponent<Text>();
        solCenter = transform.GetChild(1).transform.GetChild(2).GetComponent<Text>();

        // GET MISSION INFO

        missionTitleText = transform.GetChild(2).transform.GetChild(0).GetComponent<Text>();
        descriptionText = transform.GetChild(2).transform.GetChild(1).GetComponent<Text>();

        // FADE COMPONENTS

        sceneText.DOFade(0, 0);
        temperatureText.DOFade(0, 0);
        dayText.DOFade(0, 0);

        solLeft.DOFade(0, 0);
        solCenter.DOFade(0, 0);

        missionTitleText.DOFade(0, 0);
        descriptionText.DOFade(0, 0);

        // CRATERE GALE

        if (sceneName == "Gale Crater")
        {
            isGale = true;
            isGaleLoaded = true;
            StartCoroutine(LandInfo("Gale Crater"));
        }
        else
        {
            isGaleLoaded = false;
        }

        // ALTRE SCENE

        if (sceneName == "Noctis Labyrinthus")
        {
            isNoctis = true;
            StartCoroutine(LandInfo("Noctis Labyrinthus"));
        }

        else if (sceneName == "Olympus Mons")
        {
            isOlympus = true;
            StartCoroutine(LandInfo("Olympus Mons"));
        }

        else if (sceneName == "Valles Marineris")
        {
            isValles = true;
            StartCoroutine(LandInfo("Valles Marineris"));
        }
    }

    private void Update()
    {
        // INFO MISSION

        // QUEST1 (QUEST1)
        if (quest.transform.GetChild(0).GetComponent<Quest>().currentState == Quest.QuestState.ENABLED && !mission1)
        {
            StartCoroutine(MissionInfo("Welcome on board", "Move the player using 'WASD' or your left analogic stick", 16));
            mission1 = true;
        }

        // USA LA PALA SUI PANNELLI (QUEST1)
        else if (quest.transform.GetChild(0).transform.GetChild(2).GetComponent<TaskInteract>().currentState == Task.TaskState.READY && !mission2)
        {
            StartCoroutine(MissionInfo("Clear the Solar Panels", "Use the Action Button 'E' or 'X' to use you shovel", 5));
            mission2 = true;
        }

        // VAI ALLA VALLE MARINERIS (QUEST2)
        else if (quest.transform.GetChild(1).transform.GetChild(1).GetComponent<TaskTravel>().currentState == Task.TaskState.ENABLED && !mission3)
        {
            StartCoroutine(MissionInfo("exploring mars", "use the land rover to reach different locations on mars", 5));
            mission3 = true;
        }

        #region SOL
        if (quest.transform.GetChild(0).GetComponent<Quest>().currentState == Quest.QuestState.ENABLED && !quest1)
        {
            quest1 = true;
            StartCoroutine(SolLeftInfo());
        }
        #endregion
    }

    // START SCENE

    public IEnumerator LandInfo(string name)
    {
        #region Temperature
        if (isGaleLoaded && FindObjectOfType<GenericSettings>().isOutside == false)
        {
            dayText.text = "Time of Day: ?";
            behaviour.profile = insideBase;
        }
        else if(isGaleLoaded && FindObjectOfType<GenericSettings>().isOutside == true)
        {
            dayText.text = "Time of Day: ?";
            behaviour.profile = outsideBase;
        }

        if(isGaleLoaded == false)
        {
            if (temperatureValue >= -30)
            {
                behaviour.profile = sunset;
                dayText.text = "Time of Day: Sunset";
            }
            else
            {
                behaviour.profile = mid;
                dayText.text = "Time of Day: Midday";
            }
        }
        #endregion

        yield return new WaitForSeconds(2.5f);
        sceneText.text = name;
        sceneText.DOFade(1, 4);

        yield return new WaitForSeconds(2);
        temperatureText.text = "Temperature: " + temperatureValue + "°";
        temperatureText.DOFade(1, 2);

        yield return new WaitForSeconds(1);
        dayText.DOFade(1, 2);

        #region Icon Animations  // SONO STATE DISABILITATE LE "IMAGES" DI TUTTI GLI OGGETTI TRANNE I "COLLECTABLES"
        yield return new WaitForSeconds(0.5f);
        if (isGale)
        {
            transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(true);
            foreach(Transform child in transform.GetChild(3).transform.GetChild(0))
            {
                child.GetComponent<Animation>().Play("RotateY");
            }
        }
        else if (isValles)
        {
            transform.GetChild(3).transform.GetChild(1).gameObject.SetActive(true);
            foreach (Transform child in transform.GetChild(3).transform.GetChild(1))
            {
                child.GetComponent<Animation>().Play("RotateY");
            }
        }
        else if (isNoctis)
        {
            transform.GetChild(3).transform.GetChild(2).gameObject.SetActive(true);
            foreach (Transform child in transform.GetChild(3).transform.GetChild(2))
            {
                child.GetComponent<Animation>().Play("RotateY");
            }
        }
        else if (isOlympus)
        {
            transform.GetChild(3).transform.GetChild(3).gameObject.SetActive(true);
            foreach (Transform child in transform.GetChild(3).transform.GetChild(3))
            {
                child.GetComponent<Animation>().Play("RotateY");
            }
        }

        yield return new WaitForSeconds(6);
        if (isGale)
        {
            foreach (Transform child in transform.GetChild(3).transform.GetChild(0))
            {
                child.GetComponent<Animation>().Play("RotateYBack");
            }
            yield return new WaitForSeconds(2);
            transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(false);
            isGale = false;
        }
        else if (isValles)
        {
            foreach (Transform child in transform.GetChild(3).transform.GetChild(1))
            {
                child.GetComponent<Animation>().Play("RotateYBack");
            }
            yield return new WaitForSeconds(2);
            transform.GetChild(3).transform.GetChild(1).gameObject.SetActive(false);
            isValles = false;
        }
        else if (isNoctis)
        {
            foreach (Transform child in transform.GetChild(3).transform.GetChild(2))
            {
                child.GetComponent<Animation>().Play("RotateYBack");
            }
            yield return new WaitForSeconds(2);
            transform.GetChild(3).transform.GetChild(2).gameObject.SetActive(false);
            isNoctis = false;
        }
        else if (isOlympus)
        {
            foreach (Transform child in transform.GetChild(3).transform.GetChild(3))
            {
                child.GetComponent<Animation>().Play("RotateYBack");
            }
            yield return new WaitForSeconds(2);
            transform.GetChild(3).transform.GetChild(3).gameObject.SetActive(false);
            isOlympus = false;
        }
        #endregion

        sceneText.DOFade(0, 4);
        temperatureText.DOFade(0, 4);
        dayText.DOFade(0, 4);
    }

    public IEnumerator MissionInfo(string missionEnabled, string descriptionInfo, int seconds)
    {
        missionTitleText.text = missionEnabled;
        descriptionText.text = descriptionInfo;

        yield return new WaitForSeconds(seconds);
        missionTitleText.GetComponent<Animation>().Play("MoveLeft");
        missionTitleText.DOFade(1, 0.5f);

        yield return new WaitForSeconds(1f);
        descriptionText.GetComponent<Animation>().Play("MoveUp");
        descriptionText.DOFade(1, 1);

        yield return new WaitForSeconds(10);
        missionTitleText.GetComponent<Animation>().Play("MoveRight");
        descriptionText.GetComponent<Animation>().Play("MoveDown");
        missionTitleText.DOFade(0, 1);
        descriptionText.DOFade(0, 0.5f);
    }

    public IEnumerator SolLeftInfo()
    {
        solLeft.text = "Sol 1";

        yield return new WaitForSeconds(8f);
        solLeft.DOFade(1, 4);

        yield return new WaitForSeconds(4f);
        solLeft.DOFade(0, 4);
    }

    // CHIAMARE QUESTA NEL MANAGER DELLE QUEST
    public IEnumerator SolInfo(string name)
    {
        FindObjectOfType<GenericSettings>().LockPlayer();
        yield return new WaitForSeconds(1f);

        fadeSol.DOFade(1, 2);
        solCenter.text = name;

        yield return new WaitForSeconds(3f);
        solCenter.DOFade(1, 4);

        yield return new WaitForSeconds(4f);
        FindObjectOfType<GenericSettings>().UnlockPlayer();
        solCenter.DOFade(0, 2);
        fadeSol.DOFade(0, 4);
    }
}
