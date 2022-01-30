using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GigaBall : MonoBehaviour
{
    public float Speed;
   private Vector3 Direction;
    public GameObject player;//Jugador

    private Rigidbody2D Rigidbody2D;
    
    
    public GameObject diePEffect;
    public float dieTime;
    public int Health;
    public AudioClip sound;

    private void Start()
    {
           Camera.main.GetComponent<AudioSource>().PlayOneShot(sound);
      dieTime=3.0f;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(Timer());
         player=GameObject.FindGameObjectWithTag("Player");
      
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

        if(collisionGameObject.tag!="Boss" && collisionGameObject.tag!="Life"){
        playerController player=collision.GetComponent<playerController>();
        
        if(player!=null){
            player.Hit();
             DestroyBullet();
        }
       
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
    public void Hit() {
        Health -= 1;
        if (Health <= 0){
        DestroyBullet();
        }
        }
    
}
