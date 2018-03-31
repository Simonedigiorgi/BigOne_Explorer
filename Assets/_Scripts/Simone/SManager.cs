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

    [BoxGroup("PostProcessing Profiles")] public PostProcessingProfile mid;
    [BoxGroup("PostProcessing Profiles")] public PostProcessingProfile sunset;

    // Scena

    private Text sceneText;
    private Text temperatureText;
    private Text dayText;

    // Sol

    private Text solText;
    private bool quest1, quest2, quest3, quest4, quest5, quest6, quest7, quest8;

    // Missions

    private Text missionTitleText;
    private bool mission1;

    private int temperatureValue;

    void Start()
    {
        behaviour = FindObjectOfType<vThirdPersonCamera>().GetComponent<PostProcessingBehaviour>();
        quest = GameObject.Find("Quests");

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        temperatureValue = Random.Range(-60, 20);

        sceneText = transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        temperatureText = transform.GetChild(0).transform.GetChild(1).GetComponent<Text>();
        dayText = transform.GetChild(0).transform.GetChild(2).GetComponent<Text>();

        solText = transform.GetChild(1).transform.GetChild(0).GetComponent<Text>();

        missionTitleText = transform.GetChild(2).transform.GetChild(0).GetComponent<Text>();

        // INFO SCENA

        sceneText.DOFade(0, 0);
        temperatureText.DOFade(0, 0);
        dayText.DOFade(0, 0);

        solText.DOFade(0, 0);

        missionTitleText.DOFade(0, 0);

        if (sceneName == "Gale Crater")
            StartCoroutine(LandInfo("Gale Crater"));

        else if (sceneName == "Noctis Labyrinthus")
            StartCoroutine(LandInfo("Noctis Labyrinthus"));

        else if (sceneName == "Olympus Mons")
            StartCoroutine(LandInfo("Olympus Mons"));

        else if (sceneName == "Valles Marineris")
            StartCoroutine(LandInfo("Valles Marineris"));
    }

    private void Update()
    {
        // INFO MISSION

        if (quest.transform.GetChild(0).transform.GetChild(2).GetComponent<TaskInteract>().currentState == Task.TaskState.READY && !mission1)
        {
            mission1 = true;
            StartCoroutine(MissionInfo("Clear the Solar Panels"));
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

    public IEnumerator LandInfo(string name)
    {
        if(temperatureValue >= -30)
        {
            behaviour.profile = sunset;
            dayText.text = "Time of Day: Sunset";
        }
        else
        {
            behaviour.profile = mid;
            dayText.text = "Time of Day: Midday";
        }

        yield return new WaitForSeconds(2.5f);
        sceneText.text = name;
        sceneText.DOFade(1, 4);

        yield return new WaitForSeconds(2);
        temperatureText.text = "Temperature: " + temperatureValue + "°";
        temperatureText.DOFade(1, 2);

        yield return new WaitForSeconds(1);
        dayText.DOFade(1, 2);

        yield return new WaitForSeconds(6);
        sceneText.DOFade(0, 4);
        temperatureText.DOFade(0, 4);
        dayText.DOFade(0, 4);
    }

    public IEnumerator MissionInfo(string missionEnabled)
    {
        missionTitleText.text = missionEnabled;

        yield return new WaitForSeconds(2.5f);
        missionTitleText.DOFade(1, 4);

        yield return new WaitForSeconds(5);
        missionTitleText.DOFade(0, 4);
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
