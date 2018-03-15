using UnityEngine;
using System.Collections;
using Invector.CharacterController;

public class GenericSettings : MonoBehaviour
{
    //public float damageThreshold = 3f;
    //public float damageMultiplier = 2.85f;

    vThirdPersonController vController;

    /*float startYPos, endYPos;
    bool firstCall = true;
    bool damaged = false;*/

    bool isDead;

    void Update()
    {
        

        if (vThirdPersonController.instance.animator.GetFloat("VerticalVelocity") <= vThirdPersonController.instance.ragdollVel && 
            vThirdPersonController.instance.animator.GetFloat("GroundDistance") <= 0.1f)
        {
            vThirdPersonController.instance.currentHealth = 0;
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