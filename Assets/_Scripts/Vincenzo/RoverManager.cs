using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Invector.CharacterController;

public class RoverManager : MonoBehaviour {

    [Tooltip("Write the name of the level you want to load")]
    public string levelToLoad;
    [Tooltip("True if you need to spawn the character into a transform location on the scene to load")]
    public bool findSpawnPoint = true;
    [Tooltip("Assign here the spawnPoint name of the scene that you will load")]
    public string spawnPointName;
    private GameObject player;

	[Header("Variabili di Stefano Mauri")]
	public EventSystem eSystem; 
	public GameObject selectedButton;
	public GameObject panel;

	void Awake()
	{

		if (gameObject.name == "LAND ROVER") 
		{
			eSystem = GameObject.FindGameObjectWithTag ("eSystem").GetComponent<EventSystem> ();
			eSystem.gameObject.SetActive (false);
		}

	}

    void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag.Equals("Player"))
        {

			other.GetComponent<Invector.CharacterController.vThirdPersonInput> ().lockInput = true;

			eSystem.gameObject.SetActive (true);
			eSystem.firstSelectedGameObject = selectedButton;
			eSystem.SetSelectedGameObject(selectedButton);

			panel.SetActive (true);
            UIManager.instance.ShowScenePanel();
            Camera.main.GetComponent<vThirdPersonCamera>().lockCamera = true; 

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {

			other.GetComponent<Invector.CharacterController.vThirdPersonInput> ().lockInput = false;

			panel.SetActive (false);

            UIManager.instance.HideScenePanel();
            Camera.main.GetComponent<vThirdPersonCamera>().lockCamera = false;

        }
    }

	public void ExitMenu()
	{

		eSystem.gameObject.SetActive (false);
        vThirdPersonController.instance..GetComponent<vThirdPersonInput>().lockInput = false;

		panel.SetActive (false);
		UIManager.instance.HideScenePanel();
		Camera.main.GetComponent<vThirdPersonCamera>().lockCamera = false;

	}

    public void ChangeScene()
    {

        player = vThirdPersonController.instance.gameObject;
		player.GetComponent<vThirdPersonInput>().lockInput = false;

        var spawnPointFinderObj = new GameObject("spawnPointFinder");
        var spawnPointFinder = spawnPointFinderObj.AddComponent<vFindSpawnPoint>();
        //Debug.Log(spawnPointName+" "+gameObject.name);

        
        spawnPointFinder.AlighObjetToSpawnPoint(player, spawnPointName);

        #if UNITY_5_3_OR_NEWER
        SceneManager.LoadScene(levelToLoad);
        #else
        		Application.LoadLevel(levelToLoad);
        #endif
    }

    

}
