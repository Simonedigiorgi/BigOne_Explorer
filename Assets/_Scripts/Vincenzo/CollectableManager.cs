using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour {

    public List<vPickupItem> collectables;

    private void Awake()
    {
        collectables = new List<vPickupItem>();
        foreach(vPickupItem collectable in FindObjectsOfType<vPickupItem>())
        {
            collectables.Add(collectable);
        }
    }

    public void DecreaseCollectable(vPickupItem collectable)
    {
        collectables.Remove(collectable);
        print(collectables.Count);
    }
}
