using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    bool playerTriggered; 

	private void OnTriggerEnter(Collider other)
	{
        if(other.tag == "Player" && !playerTriggered)
        {
            GameManager.instance.gameController.spawnPoint = this.gameObject.transform;
            Database.activeCheckpoint = this.name;
            playerTriggered = true;
        }
	}

	private void OnTriggerExit(Collider other)
	{
        if (other.tag == "Player" && playerTriggered)
        {
            playerTriggered = false;
        }
	}

}
