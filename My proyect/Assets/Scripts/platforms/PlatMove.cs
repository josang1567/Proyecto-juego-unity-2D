using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatMove : MonoBehaviour
{
    public float  moveSpeed=3f;
    public float movement = 3f;
    Vector3 ori;
   public GameObject inicialPos;
    bool moveRight=true;
    void Start(){
        ori=transform.position;
    }
    void Update()
    {
        
        if(ori.x - transform.position.x<-movement){
            moveRight=false;
        }
        if(ori.x-transform.position.x>movement){
            moveRight=true;
        }
        
        if(moveRight){
            transform.position=new Vector2(transform.position.x+moveSpeed*Time.deltaTime,transform.position.y);
        }
        else{
             transform.position=new Vector2(transform.position.x-moveSpeed*Time.deltaTime,transform.position.y);
        }
    }
     void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag.Equals("Player")){
          col.transform.SetParent(transform);
        }
    }
      void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.tag.Equals("Player")){
            col.transform.SetParent(null);
        }
    }
}
