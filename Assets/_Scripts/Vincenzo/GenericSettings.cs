﻿using UnityEngine;
using Invector.CharacterController;
using System.Collections;
using DG.Tweening;

public class GenericSettings : MonoBehaviour
{

    private bool isDead;
    public bool isOutside;

    public Avatar avatarInside;
    public GameObject modelInside;

    public Avatar avatarOutside;
    public GameObject modelOutside;

    public GameObject currentModel;

    public GameObject pocketShovel;
    public GameObject handShovel;

    public bool IsDead
    {
        get { return isDead; }
        set
        {
            isDead = value;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(ChangePlayer());
        }
    }

    /*void Update()
    {
        if (vThirdPersonController.instance.animator.GetFloat("VerticalVelocity") <= vThirdPersonController.instance.ragdollVel && 
            vThirdPersonController.instance.animator.GetFloat("GroundDistance") <= 0.1f && !isDead)
        {
            this.LockPlayer();
            StartCoroutine(UIManager.instance.FadeDeath());
            isDead = true;
        }      
    }*/

    public void LockPlayer()
    {
        vThirdPersonCamera.instance.lockCamera = true;
        vThirdPersonController.instance.GetComponent<vThirdPersonInput>().lockInput = true;
        vThirdPersonController.instance.lockSpeed = true;
        vThirdPersonController.instance.lockRotation = true;
    }

    public void UnlockPlayer()
    {
        vThirdPersonCamera.instance.lockCamera = false;
        vThirdPersonController.instance.GetComponent<vThirdPersonInput>().lockInput = false;
        vThirdPersonController.instance.lockSpeed = false;
        vThirdPersonController.instance.lockRotation = false;
    }

    public IEnumerator ChangePlayer()
    {
        LockPlayer();

        Sequence astronautAnimation = DOTween.Sequence();

        astronautAnimation.Append(UIManager.instance.fadeImage.DOFade(1, 1f));
        yield return astronautAnimation.WaitForCompletion();

        if (currentModel == modelInside)
        {
            modelInside.SetActive(false);
            this.gameObject.GetComponent<Animator>().avatar = avatarOutside;
            modelOutside.SetActive(true);
            currentModel = modelOutside;

            vThirdPersonController.instance.transform.position = new Vector3(vThirdPersonController.instance.transform.position.x + 5f,
                                                                             vThirdPersonController.instance.transform.position.y, 
                                                                             vThirdPersonController.instance.transform.position.z);
        }
        else
        {
            modelOutside.SetActive(false);
            this.gameObject.GetComponent<Animator>().avatar = avatarInside;
            modelInside.SetActive(true);
            currentModel = modelInside;

            vThirdPersonController.instance.transform.position = new Vector3(vThirdPersonController.instance.transform.position.x - 5f,
                                                                             vThirdPersonController.instance.transform.position.y,
                                                                             vThirdPersonController.instance.transform.position.z);
        }

        yield return new WaitForSeconds(0.5f);

        UIManager.instance.fadeImage.DOFade(0, 1f);
        UnlockPlayer();

    }


}