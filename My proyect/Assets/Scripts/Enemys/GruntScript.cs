using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{ 
    public GameObject BulletPrefab;
    private GameObject player;//Jugador
    private float LastShoot;
    public int Health=15;
    public GameObject diePEffect;
    

      //movimiento
     public bool mustPatrol;
    private Rigidbody2D rb;
    public float walkSpeed;
    public Transform groundCheckPos;
    public bool mustTurn;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public AudioClip impacto;
    
    //animaciones
    
    public bool isAlive;
        void Start()
    {
        isAlive=true;
        mustPatrol=true;
        rb=GetComponent<Rigidbody2D>(); 
        player=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        //
        if(mustPatrol){
            Patrol();
        }
        //
        if(player==null){
            return;
        }

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
            Shoot();
            LastShoot=Time.time;
            
        }


    }
    private void Shoot(){
        
      int Direction(){
          if (transform.localScale.x<0f){
                return-1;
            }else{
                return+1;
            }
      }
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject bullet= Instantiate(BulletPrefab,transform.position+direction*1.5f,Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
        bullet.GetComponent<Rigidbody2D>().velocity=new Vector2( bullet.GetComponent<BulletScript>().GetSpeed()*Direction()*Time.fixedDeltaTime,0f);
    
    }
    public void Hit()
    {
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

    //movimiento
    void Patrol() {
        if(mustTurn || bodyCollider.IsTouchingLayers(groundLayer) ) {
            Flip();
        }
     rb.velocity   = new Vector2(walkSpeed+Time.fixedDeltaTime, rb.velocity.y);

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
    void OnTriggerEnter2D(Collider2D c){
        
        if(c.gameObject.tag=="Enemy"||c.gameObject.tag=="Boss" || bodyCollider.IsTouchingLayers(groundLayer)){
            Flip();
        }
    }
    private void FixedUpdate(){
        if(mustPatrol){
            mustTurn=!Physics2D.OverlapCircle(groundCheckPos.position,-0.1f, groundLayer);
        }
         
    }
}
