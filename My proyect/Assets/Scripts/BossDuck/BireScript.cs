using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BireScript : MonoBehaviour
{
    // Start is called before the first frame update
private void  OnTriggerEnter2D(Collider2D collision){
        
        GameObject collisionGameObject=collision.gameObject;
        playerController player=collision.GetComponent<playerController>();
        
        if(player!=null){
            player.Hit();
        }
        
        }
}
