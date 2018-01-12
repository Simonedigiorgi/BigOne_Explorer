 using UnityEngine;
 using System.Collections;
 
 public class ParticleSystemAutoDestroyer : MonoBehaviour 
 {
     private ParticleSystem ps;
	 private float timer = 0;

     public void OnEnable() 
     {
         ps = GetComponent<ParticleSystem>();
     }
 
     public void Update() 
     {
		
		timer += Time.deltaTime;
		
		if(timer >= 1.5)
		{
		
			 Destroy(gameObject);

		}

         if(ps)
         {
             if(!ps.IsAlive())
             {
                 Destroy(gameObject);
             }
         }
     }
 }