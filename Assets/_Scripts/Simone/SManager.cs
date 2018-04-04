using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.PostProcessing;
using UnityEngine.Rendering;
using Sirenix.OdinInspector;
using DG.Tweening;

public class SManager : MonoBehaviour {

    private PostProcessingBehaviour behaviour;
    private GameObject quest;

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

    private Text solText;
    private bool quest1, quest2, quest3, quest4, quest5, quest6, quest7, quest8;

    // Missions

    private Text missionTitleText;
    private Text descriptionText;
    private bool mission1, mission2, mission3;

    // Icons

    private Image firstIconImage;

    private int temperatureValue;

    private bool isGale;
    private bool isValles;
    private bool isNoctis;
    private bool isOlympus;

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

        solText = transform.GetChild(1).transform.GetChild(0).GetComponent<Text>();

        // GET MISSION INFO

        missionTitleText = transform.GetChild(2).transform.GetChild(0).GetComponent<Text>();
        descriptionText = transform.GetChild(2).transform.GetChild(1).GetComponent<Text>();

        // GET ICONS INFO

        firstIconImage = transform.GetChild(3).transform.GetChild(0).GetComponent<Image>();

        // FADE COMPONENTS

        sceneText.DOFade(0, 0);
        temperatureText.DOFade(0, 0);
        dayText.DOFade(0, 0);

        solText.DOFade(0, 0);

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
            StartCoroutine(SolInfo("Sol 1"));
        }
        else if (quest.transform.GetChild(1).GetComponent<Quest>().currentState == Quest.QuestState.ENABLED && !quest2)
        {
            quest2 = true;
            StartCoroutine(SolInfo("Sol 6"));
        }
        else if (quest.transform.GetChild(2).GetComponent<Quest>().currentState == Quest.QuestState.ENABLED && !quest3)
        {
            quest3 = true;
            StartCoroutine(SolInfo("Sol 15"));
        }
        else if (quest.transform.GetChild(3).GetComponent<Quest>().currentState == Quest.QuestState.ENABLED && !quest4)
        {
            quest4 = true;
            StartCoroutine(SolInfo("Sol 21"));
        }
        else if (quest.transform.GetChild(4).GetComponent<Quest>().currentState == Quest.QuestState.ENABLED && !quest5)
        {
            quest5 = true;
            StartCoroutine(SolInfo("Sol 28"));
        }
        else if (quest.transform.GetChild(5).GetComponent<Quest>().currentState == Quest.QuestState.ENABLED && !quest6)
        {
            quest6 = true;
            StartCoroutine(SolInfo("Sol 34"));
        }
        else if (quest.transform.GetChild(6).GetComponent<Quest>().currentState == Quest.QuestState.ENABLED && !quest7)
        {
            quest7 = true;
            StartCoroutine(SolInfo("Sol 41"));
        }
        else if (quest.transform.GetChild(7).GetComponent<Quest>().currentState == Quest.QuestState.ENABLED && !quest8)
        {
            quest8 = true;
            StartCoroutine(SolInfo("Sol 49"));
        }
        #endregion
    }

    // START SCENE

    public IEnumerator LandInfo(string name)
    {
        // TEMPERATURE

        if (isGaleLoaded && FindObjectOfType<GenericSettings>().isOutside == false)
        {
            dayText.text = "Time of Day: ?";
            behaviour.profile = insideBase;
            Debug.Log("The Player is Inside the base");
        }
        else if(isGaleLoaded && FindObjectOfType<GenericSettings>().isOutside == true)
        {
            dayText.text = "Time of Day: ?";
            behaviour.profile = outsideBase;
            Debug.Log("The Player is Outside the base");
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

        yield return new WaitForSeconds(2.5f);
        sceneText.text = name;
        sceneText.DOFade(1, 4);

        yield return new WaitForSeconds(2);
        temperatureText.text = "Temperature: " + temperatureValue + "°";
        temperatureText.DOFade(1, 2);

        yield return new WaitForSeconds(1);
        dayText.DOFade(1, 2);

        #region Icon Animations
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

    public IEnumerator SolInfo(string solNumber)
    {
        solText.text = solNumber;

        yield return new WaitForSeconds(8f);
        solText.DOFade(1, 4);

        yield return new WaitForSeconds(4f);
        solText.DOFade(0, 4);
    }
}
