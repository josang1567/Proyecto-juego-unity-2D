using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurController : MonoBehaviour
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
    public int maxhealth;
    public AudioClip impacto;
  
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
        speed=3f;
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
           Camera.main.GetComponent<AudioSource>().PlayOneShot(impacto);
        Health -= 2;
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
             Health+=1;
             if(Health>maxhealth){
             Health=maxhealth;
         }
         }
         
     }
     public void slice(){
          Camera.main.GetComponent<AudioSource>().PlayOneShot(ataque);
     }
}
