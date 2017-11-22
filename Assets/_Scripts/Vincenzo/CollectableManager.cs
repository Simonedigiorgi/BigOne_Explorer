using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Invector.CharacterController;

public class CollectableManager : MonoBehaviour {

    public List<vPickupItem> collectables;
    public vHUDController hudController;

    private void Awake()
    {
        hudController = FindObjectOfType<vHUDController>();
        collectables = new List<vPickupItem>();
        foreach(vPickupItem collectable in FindObjectsOfType<vPickupItem>())
        {
            collectables.Add(collectable);
        }
    }

    public void DecreaseCollectable(vPickupItem collectable)
    {
        collectables.Remove(collectable);
        if(collectables.Count <= 0)
        {
            Camera.main.GetComponent<vThirdPersonCamera>().lockCamera = true;
            hudController.transform.GetChild(8).gameObject.SetActive(true);
        }
    }

    public void Restart()
    {
        var spawnPointFinderObj = new GameObject("spawnPointFinder");
        var spawnPointFinder = spawnPointFinderObj.AddComponent<vFindSpawnPoint>();
        spawnPointFinder.AlighObjetToSpawnPoint(FindObjectOfType<vThirdPersonController>().gameObject, "Restart");

        SceneManager.LoadScene("_Main_Alessandro");
    }
}
