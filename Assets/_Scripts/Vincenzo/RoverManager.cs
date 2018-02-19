using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

	void Awake()
	{

		player = GameObject.FindGameObjectWithTag("Player");

	}

    void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag.Equals("Player"))
        {

			//player.GetComponent<Invector.CharacterController.vThirdPersonInput> ().lockInput = false;

			eSystem.gameObject.SetActive (true);
			eSystem.SetSelectedGameObject(selectedButton);

            UIManager.instance.ShowScenePanel();
            Camera.main.GetComponent<vThirdPersonCamera>().lockCamera = true; 

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {

			//player.GetComponent<Invector.CharacterController.vThirdPersonInput> ().enabled = true;

			eSystem.SetSelectedGameObject(null);
			eSystem.gameObject.SetActive (false);

            UIManager.instance.HideScenePanel();
            Camera.main.GetComponent<vThirdPersonCamera>().lockCamera = false;

        }
    }

    public void ChangeScene()
    {
        var spawnPointFinderObj = new GameObject("spawnPointFinder");
        var spawnPointFinder = spawnPointFinderObj.AddComponent<vFindSpawnPoint>();
        //Debug.Log(spawnPointName+" "+gameObject.name);

        //player = GameObject.FindGameObjectWithTag("Player");
        spawnPointFinder.AlighObjetToSpawnPoint(player, spawnPointName);

        #if UNITY_5_3_OR_NEWER
        SceneManager.LoadScene(levelToLoad);
        #else
        		Application.LoadLevel(levelToLoad);
        #endif
    }

    

}
