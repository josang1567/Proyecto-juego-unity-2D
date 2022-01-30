using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
  
      public float speed;
    private GameObject player;
    public int Health;
    public GameObject diePEffect;
    public bool isAlive;
    public bool isAttacking;
    private Animator anim;
 
    public Transform startingpoint;
    public AudioClip ataque;
    public AudioClip impacto;
    //disparo
    public Transform shootPos;
     public GameObject Bala1;

  
    [HideInInspector]
    public bool chase;
        void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        anim=GetComponent<Animator>();
    }

   
    void Update()
    {
        if(player==null){
        return;

        }
    if(chase==true){
         Chase();
    }else{
        ReturnStartPoint();
        
    }
      if(transform.position.x==startingpoint.transform.position.x ){
            speed=0;
        }
        Flip();
        heal();
    }
    private void Chase(){
        speed=1;
        transform.position=Vector2.MoveTowards(transform.position,player.transform.position,speed*Time.deltaTime);

        if(Vector2.Distance(transform.position, player.transform.position)<=0.5f){
            //disparar atacar, etc
        }else{
            //reset values
            
        }
    }
    private void Flip(){
        if(transform.position.x>player.transform.position.x){
            transform.localScale=new Vector3(1.0f,1.0f,1.0f);
        }else if(transform.position.x<player.transform.position.x){
            transform.localScale=new Vector3(-1.0f,1.0f,1.0f);
        }
    }
    private void ReturnStartPoint(){
        transform.position=Vector2.MoveTowards(transform.position,startingpoint.position,speed*Time.deltaTime);
       
    }
       
   
      public void Hit() {
        Health -= 2;
         Camera.main.GetComponent<AudioSource>().PlayOneShot(impacto);
        if (Health <= 0){
        death();
        }
        }
        public void death(){
           if(diePEffect!=null){
            Instantiate(diePEffect,transform.position, Quaternion.identity);
        }
         Destroy(gameObject);
    }
     private void FixedUpdate(){

       anim.SetBool("IsAlive",isAlive);
        anim.SetBool("IsAttacking",isAttacking);
        anim.SetFloat("Speed",speed);

     }
     void heal(){
         if(chase==false){
             Health+=4;
         }
         if(Health>=20){
             Health=20;
         }
     }
     public void slice(){
          Camera.main.GetComponent<AudioSource>().PlayOneShot(ataque);
     }
     public void shoot(){
         int Direction(){
          if (transform.localScale.x<0f){
                return-1;
            }else{
                return+1;
            }
      }
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject bullet= Instantiate(Bala1,shootPos.transform.position+direction*1.5f,Quaternion.identity);
        bullet.GetComponent<GigaBall>().SetDirection(direction);
        bullet.GetComponent<Rigidbody2D>().velocity=new Vector2( bullet.GetComponent<GigaBall>().GetSpeed()*Direction()*Time.fixedDeltaTime,0f);
        
     }
}
