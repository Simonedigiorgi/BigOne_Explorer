using UnityEngine;
using System.Collections;
using Invector.CharacterController;

public class vFallDamageManager : MonoBehaviour
{
    public float damageThreshold = 3f;
    public float damageMultiplier = 2.85f;

    vThirdPersonController vController;

    float startYPos, endYPos;
    bool firstCall = true;
    bool damaged = false;

    bool isDead;


    void Awake()
    {
        vController = GetComponent<vThirdPersonController>();
    }


    void Update()
    {
        

            if (vController.animator.GetFloat("VerticalVelocity") <= -16f && vController.animator.GetFloat("GroundDistance") <= 0.1f)
            {
                vController.currentHealth = 0;
            }
            
        
        /*else
        {
            endYPos = transform.position.y;
            if (damaged && (startYPos - endYPos) > damageThreshold)
            {
                damaged = false;
                firstCall = true;

                float amount = startYPos - endYPos - damageThreshold;
                float damage = (damageMultiplier == 0f) ? amount : amount * damageMultiplier;
                vController.currentHealth -= Mathf.Round(damage);
            }
        }*/
    }
}