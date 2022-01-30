using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinoAttack : MonoBehaviour

{
     public MinotaurController[] enemyArray;
     private bool attackMode,cooling;
        public float timer;

    private float intTimer;

    void Start(){
        intTimer=timer;
    }
     private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            foreach(MinotaurController enemy in enemyArray){
                enemy.isAttacking=true;
                timer=intTimer;
                if(cooling==true){
            Cooldown();
                }
                
            }
        }
    }
     private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            foreach(MinotaurController enemy in enemyArray){
                enemy.isAttacking=false;
                 StopAttack();
            }
        }
    }
    void StopAttack(){
        cooling=false;
        enemyArray[0].isAttacking=false;
    }
     public void TriggerCooling(){
        cooling=true;
    }
    void Cooldown(){
        timer-=Time.deltaTime;
        if(timer<=0 && cooling==true&&attackMode==true){
            cooling=false;
            timer=intTimer;
        }
    }
}
