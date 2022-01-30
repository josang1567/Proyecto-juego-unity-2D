using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curacion : MonoBehaviour
{
   public AudioClip sound;

   private void OnTriggerEnter2D (Collider2D collision){
         playerController player=collision.GetComponent<playerController>();
         if(player!=null){
           player.Cura(1);      
         GameControlScript.health+=1;    
          Camera.main.GetComponent<AudioSource>().PlayOneShot(sound);  
            Destroy(gameObject);
         }
        
     }
}
