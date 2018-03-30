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

    [BoxGroup("PostProcessing Profiles")] public PostProcessingProfile mid;
    [BoxGroup("PostProcessing Profiles")] public PostProcessingProfile sunset;

    private Text sceneText;
    private Text temperatureText;
    private Text dayText;

    private int temperatureValue;

    void Start()
    {
        behaviour = FindObjectOfType<vThirdPersonCamera>().GetComponent<PostProcessingBehaviour>();

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        temperatureValue = Random.Range(-140, 20);

        sceneText = transform.GetChild(0).GetComponent<Text>();
        temperatureText = transform.GetChild(1).GetComponent<Text>();
        dayText = transform.GetChild(2).GetComponent<Text>();

        sceneText.DOFade(0, 0);
        temperatureText.DOFade(0, 0);
        dayText.DOFade(0, 0);

        if (sceneName == "Gale Crater")
            StartCoroutine(AnimateText("Gale Crater"));

        else if (sceneName == "Noctis Labyrinthus")
            StartCoroutine(AnimateText("Noctis Labyrinthus"));

        else if (sceneName == "Olympus Mons")
            StartCoroutine(AnimateText("Olympus Mons"));

        else if (sceneName == "Valles Marineris")
            StartCoroutine(AnimateText("Valles Marineris"));
    }
    
    public IEnumerator AnimateText(string name)
    {
        if(temperatureValue >= -80)
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
}
