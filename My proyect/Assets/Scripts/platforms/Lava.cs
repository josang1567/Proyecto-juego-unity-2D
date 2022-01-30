using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
   
     private void OnTriggerEnter2D (Collider2D collision){
         playerController player=collision.GetComponent<playerController>();
         if(player!=null){
           
                player.Hit();
                
                player.Hit();

                player.Hit();

                player.Hit();

                player.Hit();
                player.Hit();
                
                player.Hit();

                player.Hit();

                player.Hit();

               

         }
     }

}
