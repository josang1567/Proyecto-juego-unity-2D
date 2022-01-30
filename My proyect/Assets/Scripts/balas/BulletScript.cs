using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
   private Vector3 Direction;

    private Rigidbody2D Rigidbody2D;
    public GameObject player;//Jugador
    
    public GameObject diePEffect;
    public float dieTime;
    private void Start()
    {
      dieTime=3.0f;
      player=GameObject.FindGameObjectWithTag("Player");
        Rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(Timer());
      
    }
    void Update(){
         Vector3 direction = player.transform.position-transform.position;
        if(direction.x>=0.0f){
          transform.localScale=new Vector3(1.0f,1.0f,1.0f);
          
        }else{
             transform.localScale=new Vector3(-1.0f,1.0f,1.0f);
             
        }
    }
    private void FixedUpdate()
    {
      
        Rigidbody2D.velocity = Direction*Mathf.Abs(Speed) ;
    }
 public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

  
    private void  OnTriggerEnter2D(Collider2D collision){

          GameObject collisionGameObject=collision.gameObject;
        if( collisionGameObject.tag!="ChaseTrigger"&& collisionGameObject.tag!="Life"){
        playerController player=collision.GetComponent<playerController>();

        if(player!=null){
            player.Hit();
        }
         DestroyBullet();
        }
      
        
   
    }
     public void DestroyBullet()
    {
        if(diePEffect!=null){
            Instantiate(diePEffect,transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
IEnumerator Timer(){
        yield return new WaitForSeconds(dieTime);
        DestroyBullet();
    }
   public float GetSpeed(){
        return this.Speed;
    }
    public Vector3 GetDirection(){
        return this.Direction;
    }
}