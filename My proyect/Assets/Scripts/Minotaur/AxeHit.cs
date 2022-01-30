using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHit : MonoBehaviour
{
    public MinotaurController Mino;

   private void  OnTriggerEnter2D(Collider2D collision){
        
        GameObject collisionGameObject=collision.gameObject;
        playerController player=collision.GetComponent<playerController>();
        
        if(player!=null){
            player.Hit();
        }
        
        }

}
