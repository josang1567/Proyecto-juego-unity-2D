using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endgame : MonoBehaviour
{
   public bool IsEnable;
  public MinotaurController mino ;
 playerController player;

    void Start()
    {
        IsEnable=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(mino.isAlive==false){
            IsEnable=true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
       
      // if(IsEnable==true){
        GameObject collisionGameObject=collision.gameObject;
        Debug.Log(collisionGameObject.name);
        if(collisionGameObject.name=="player"){
            
             Time.timeScale=0;

          
        }
      // }
       
    }
  
}
