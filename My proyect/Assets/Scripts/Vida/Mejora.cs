using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mejora : MonoBehaviour
{
   public int mejora;
   public AudioClip sound;

    // Start is called before the first frame update
   private void OnTriggerEnter2D (Collider2D collision){
         playerController player=collision.GetComponent<playerController>();
         if(player!=null){
           player.Mejora(mejora);
           GameControlScript.health+=mejora;
            Camera.main.GetComponent<AudioSource>().PlayOneShot(sound);          
            Destroy(gameObject);
         }
        
     }
}
