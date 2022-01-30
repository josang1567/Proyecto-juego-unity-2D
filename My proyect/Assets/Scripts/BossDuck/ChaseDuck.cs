using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseDuck : MonoBehaviour
{
    // Start is called before the first frame update
   public BossController[] enemyArray;

  
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            foreach(BossController enemy in enemyArray){
                enemy.chase=true;
            }
        }
    }
     private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            foreach(BossController enemy in enemyArray){
                enemy.chase=false;
            }
        }
    }
}
