using UnityEngine;
using UnityEngine.SceneManagement;

public class RoverManager : MonoBehaviour {

    [Tooltip("Write the name of the level you want to load")]
    public string levelToLoad;
    [Tooltip("True if you need to spawn the character into a transform location on the scene to load")]
    public bool findSpawnPoint = true;
    [Tooltip("Assign here the spawnPoint name of the scene that you will load")]
    public string spawnPointName;
    private GameObject hud;
    private GameObject player;

    private void Awake()
    {
        hud = FindObjectOfType<vHUDController>().gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            hud.transform.GetChild(7).gameObject.SetActive(true);
            Camera.main.GetComponent<vThirdPersonCamera>().lockCamera = true; 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            hud.transform.GetChild(7).gameObject.SetActive(false);
            Camera.main.GetComponent<vThirdPersonCamera>().lockCamera = false;
        }
    }

    public void ChangeScene()
    {
        var spawnPointFinderObj = new GameObject("spawnPointFinder");
        var spawnPointFinder = spawnPointFinderObj.AddComponent<vFindSpawnPoint>();
        //Debug.Log(spawnPointName+" "+gameObject.name);

        player = GameObject.FindGameObjectWithTag("Player");
        spawnPointFinder.AlighObjetToSpawnPoint(player, spawnPointName);

        #if UNITY_5_3_OR_NEWER
        SceneManager.LoadScene(levelToLoad);
        #else
        		Application.LoadLevel(levelToLoad);
        #endif
    }

    public void HideChangeScene()
    {
        hud.transform.GetChild(7).gameObject.SetActive(false);
        Camera.main.GetComponent<vThirdPersonCamera>().lockCamera = false;
    }

}
