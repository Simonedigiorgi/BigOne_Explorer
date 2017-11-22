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

    public void ChangeScene(GameObject player)
    {
        var spawnPointFinderObj = new GameObject("spawnPointFinder");
        var spawnPointFinder = spawnPointFinderObj.AddComponent<vFindSpawnPoint>();

        spawnPointFinder.AlighObjetToSpawnPoint(player, spawnPointName);
        SceneManager.LoadScene(levelToLoad);
    }

    public void HideChangeScene()
    {
        hud.transform.GetChild(7).gameObject.SetActive(false);
        Camera.main.GetComponent<vThirdPersonCamera>().lockCamera = false;
    }

}
