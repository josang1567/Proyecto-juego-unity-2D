using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanaController : MonoBehaviour
{
    //movimiento
      [HideInInspector]
    public bool mustPatrol;
    private Rigidbody2D rb;
    public float walkSpeed;
    public Transform groundCheckPos;
     public bool mustTurn;
     public LayerMask groundLayer;
     public Collider2D bodyCollider;
     //Disparo
     public float range, timeBTWShots, shootSpeed;
     private float distToPlayer;
    public Transform  shootPos;
    public GameObject bala;
    private bool canShoot;
    private GameObject player;//Jugador

    public int Health=2;
    public GameObject diePEffect;
    public bool isAlive;
    private float LastShoot;

    void Start()
    {
        mustPatrol=true;
        canShoot=true;
        player=GameObject.FindGameObjectWithTag("Player");
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento
      if(mustPatrol)  {
          Patrol();
      }
      if(player==null){
            return;
        }
      //disparo
        Vector3 direction = player.transform.position-transform.position;
        float d= Mathf.Abs(direction.x);
        if(d < 9f){
            if(direction.x<0){
                 walkSpeed=-1;
             transform.localScale=new Vector3(-1.0f,1.0f,1.0f);
            }else{
                 transform.localScale=new Vector3(1.0f,1.0f,1.0f);
          walkSpeed=1;
            }
        }
     
       
        if(d<5.0f  && Time.time>LastShoot+1.25f){
            canShoot=true;
            LastShoot=Time.time;
            
        }
         if(canShoot==true){
                 Shoot();
                 }

       
    
    }

    private void FixedUpdate(){
        if(mustPatrol){
            mustTurn=!Physics2D.OverlapCircle(groundCheckPos.position,-0.1f, groundLayer);
        }
    }

    void Patrol() {
        if(mustTurn || bodyCollider.IsTouchingLayers(groundLayer) ) {
            Flip();
        }
     rb.velocity   = new Vector2(walkSpeed+Time.fixedDeltaTime, rb.velocity.y);

    }
    void OnTriggerEnter2D(Collider2D c){
        if(c.gameObject.tag=="Enemy"||c.gameObject.tag=="Boss"){
            Flip();
        }
    }
    void Flip(){
       if(walkSpeed==-1){
           
          transform.localScale=new Vector3(1.0f,1.0f,1.0f);
          walkSpeed=1;
        }else if(walkSpeed==1){
             walkSpeed=-1;
             transform.localScale=new Vector3(-1.0f,1.0f,1.0f);
        }
    }
  // funciones de disparo

   private void Shoot(){
        mustPatrol=false;
      int Direction(){
          if (transform.localScale.x<0f){
                return-1;
            }else{
                return+1;
            }
      }

        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject bullet= Instantiate(bala,shootPos.transform.position,Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
        bullet.GetComponent<Rigidbody2D>().velocity=new Vector2( bala.GetComponent<BulletScript>().GetSpeed()*Direction()*Time.fixedDeltaTime,0f);
    mustPatrol=true;
    }
     public void Hit()
    {
        Health -= 1;
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
}
