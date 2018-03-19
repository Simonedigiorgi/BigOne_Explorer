using UnityEngine;
using Invector.CharacterController;

public class GenericSettings : MonoBehaviour
{

    private bool isDead;

    public bool IsDead
    {
        get { return isDead; }
        set
        {
            isDead = value;
        }
    }

    void Update()
    {
        if (vThirdPersonController.instance.animator.GetFloat("VerticalVelocity") <= vThirdPersonController.instance.ragdollVel && 
            vThirdPersonController.instance.animator.GetFloat("GroundDistance") <= 0.1f && !isDead)
        {
            this.LockPlayer();
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