using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Invector.CharacterController;

public class CinemachineManager : MonoBehaviour {

    bool cutsceneActived;
    PlayableDirector playableDirector;
	
	// Update is called once per frame
	void Update ()
    {

        if(Input.GetKeyDown(KeyCode.L))
        {
            GameObject c = GameObject.FindGameObjectWithTag("Picture").transform.GetChild(1).gameObject;
            StartCutscene(c);
        }

		if(cutsceneActived && playableDirector)
        {
            if (playableDirector.state == PlayState.Paused)
            {
                playableDirector.Stop();
                playableDirector.transform.parent.gameObject.SetActive(false);
                cutsceneActived = false;
                vThirdPersonController.instance.GetComponent<GenericSettings>().UnlockPlayer();
                vThirdPersonCamera.instance.GetComponent<Cinemachine.CinemachineBrain>().enabled = false;
            }
        }
	}

    public void StartCutscene(GameObject cutscene)
    {
        if(cutscene)
        {
            vThirdPersonController.instance.GetComponent<GenericSettings>().LockPlayer();
            vThirdPersonCamera.instance.GetComponent<Cinemachine.CinemachineBrain>().enabled = true;
            cutscene.SetActive(true);
            playableDirector = cutscene.GetComponentInChildren<PlayableDirector>(true);
            playableDirector.Play();
            cutsceneActived = true;
            
        }
        

    }

    public void StopCutscene()
    {

    }

}
