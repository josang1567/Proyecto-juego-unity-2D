using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasegiga : MonoBehaviour
{
     public Gigadramon[] area;

  
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            foreach(Gigadramon giga in area){
                giga.chase=true;
            }
        }
    }
     private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
           foreach(Gigadramon giga in area){
                giga.chase=true;
            }
        }
    }
}
