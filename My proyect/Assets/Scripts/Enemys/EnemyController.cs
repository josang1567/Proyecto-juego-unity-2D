using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   
      
      private bool mustPatrol;
    private Rigidbody2D rb;
   
    public float walkSpeed;
    private float distToPlayer;
    public Transform groundCheckPos;
     public bool mustTurn;
     public LayerMask groundLayer;
     public Collider2D bodyCollider;
   public AudioClip impacto;
   public int Health=1;
    public GameObject diePEffect;
    public bool isAlive;
    void Start()
    {
        mustPatrol=true;
        rb=GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
      if(mustPatrol)  {
          Patrol();
      }
    
    }

    private void FixedUpdate(){
        if(mustPatrol){
            mustTurn=!Physics2D.OverlapCircle(groundCheckPos.position,-0.1f, groundLayer);
        }
    }

    void Patrol() {
        if(mustTurn || bodyCollider.IsTouchingLayers(groundLayer )|| bodyCollider.tag=="Player" ) {
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
        mustPatrol=false;
        transform.localScale= new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed*=-1;
        mustPatrol=true;
    }
    public void Hit()
    {
        Health -= 1;
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
}
