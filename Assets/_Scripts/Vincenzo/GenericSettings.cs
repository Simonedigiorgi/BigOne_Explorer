using UnityEngine;
using System.Collections;
using Invector.CharacterController;
using UnityEngine.UI;
using DG.Tweening;

public class GenericSettings : MonoBehaviour
{

    bool isDead;

    void Update()
    {
        if (vThirdPersonController.instance.animator.GetFloat("VerticalVelocity") <= vThirdPersonController.instance.ragdollVel && 
            vThirdPersonController.instance.animator.GetFloat("GroundDistance") <= 0.1f && !isDead)
        {
            vThirdPersonController.instance.currentHealth = 0;
            StartCoroutine(UIManager.instance.FadeDeath());
            isDead = true;
        }      
    }

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


}