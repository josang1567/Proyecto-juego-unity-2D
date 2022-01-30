using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gigadramon : MonoBehaviour
{
    public float speed;
    private GameObject player;
    
    public Transform[] Waypoints;
    int I=0;
    public int Health;
    public GameObject diePEffect;
    public bool isAlive;
    public bool isAttacking,attack1,attack2;
    private Animator anim;
    public GameObject Bala1,Bala2;
    public Transform shootPos;
    public Transform shootPos2;
    public AudioClip impacto;
    [HideInInspector]
    public bool chase;

        void Start()
    {
        chase=false;
        isAttacking=false;
        attack1=false;
        attack2=false;
        isAlive=true;
        transform.position=Waypoints[I].transform.position;
        player=GameObject.FindGameObjectWithTag("Player");
        anim=GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(player==null){
        return;

        }
    if(chase==true){
          move();

      if(transform.position==Waypoints[0].position){
          
           isAttacking=true;
           attack1=true;
       }
       if(transform.position==Waypoints[3].position){
          
           isAttacking=true;
           attack2=true;
       }
        Flip();
    }
    


    }
    
    void move(){
       if(isAttacking==false){
        transform.position=Vector2.MoveTowards(transform.position,Waypoints[I].transform.position,speed*Time.deltaTime);
       
       

        if(transform.position==Waypoints[I].transform.position){
            I+=1;
           
        }if(I==Waypoints.Length){
            I=0;
            
        }
       }
       
        
    }
  
   void Flip(){
        if(transform.position==Waypoints[0].position){
           
          transform.localScale=new Vector3(1.0f,1.0f,1.0f);
         
        }else if(transform.position==Waypoints[2].position){
             
             transform.localScale=new Vector3(-1.0f,1.0f,1.0f);
        }
    }
    
   


    public void Shoot(){
      if(attack1==true){
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
        attack1=false;

      }else if(attack2==true){
           int Direction(){
          if (transform.localScale.x<0f){
                return-1;
            }else{
                return+1;
            }
      }
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject bullet= Instantiate(Bala2,shootPos.transform.position+direction*1.5f,Quaternion.identity);
        bullet.GetComponent<GigaBall>().SetDirection(direction);
        bullet.GetComponent<Rigidbody2D>().velocity=new Vector2( bullet.GetComponent<GigaBall>().GetSpeed()*Direction()*Time.fixedDeltaTime,0f);
        
        GameObject bullet2= Instantiate(Bala2,shootPos2.transform.position+direction*1.5f,Quaternion.identity);
        bullet2.GetComponent<GigaBall>().SetDirection(direction);
        bullet2.GetComponent<Rigidbody2D>().velocity=new Vector2( bullet2.GetComponent<GigaBall>().GetSpeed()*Direction()*Time.fixedDeltaTime,0f);
        attack2=false;

      }     
              
        isAttacking=false;
        
    }
    
      public void Hit() {
        Health -= 1;
        Camera.main.GetComponent<AudioSource>().PlayOneShot(impacto);

        if (Health <= 0){
        isAlive=false;
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

     }


}

