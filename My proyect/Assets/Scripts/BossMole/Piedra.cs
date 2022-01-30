using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piedra : MonoBehaviour
{
    public float Speed;
   private Vector3 Direction;
    public GameObject player;//Jugador

    private Rigidbody2D Rigidbody2D;
    
    
    public GameObject diePEffect;
    public float dieTime;
    private void Start()
    {
      dieTime=3.0f;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(Timer());
       player=GameObject.FindGameObjectWithTag("Player");
    }
    void Update(){
     
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
        playerController player=collision.GetComponent<playerController>();
        GruntScript grunt = collision.GetComponent<GruntScript>();

        if(player!=null){
            player.Hit();
        }
        
    DestroyBullet();
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
