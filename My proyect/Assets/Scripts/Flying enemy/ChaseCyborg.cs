using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCyborg : MonoBehaviour
{
    public BatCyborg[] enemyArray;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            foreach(BatCyborg enemy in enemyArray){
                enemy.chase=true;
            }
        }
    }
     private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            foreach(BatCyborg enemy in enemyArray){
                enemy.chase=false;
            }
        }
    }
}
