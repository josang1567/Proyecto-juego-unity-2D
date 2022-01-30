using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCyborg : MonoBehaviour
{
        public float speed;
    private GameObject player;
    public bool chase=false;
    public Transform startingpoint;
     public int Health=8;
     public GameObject diePEffect;
public AudioClip impacto;
        void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
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
      
        Flip();
    }
    private void Chase(){
        transform.position=Vector2.MoveTowards(transform.position,player.transform.position,speed*Time.deltaTime);

        if(Vector2.Distance(transform.position, player.transform.position)<=0.5f){
            //disparar atacar, etc
        }else{
            //reset values
        }
    }
    private void Flip(){
        if(transform.position.x>player.transform.position.x){
            transform.rotation=Quaternion.Euler(0,0,0);
        }else if(transform.position.x<player.transform.position.x){
            transform.rotation=Quaternion.Euler(0,180,0);
        }
    }
    private void ReturnStartPoint(){
        transform.position=Vector2.MoveTowards(transform.position,startingpoint.position,speed*Time.deltaTime);
    }
     private void  OnTriggerEnter2D(Collider2D collision){
        playerController player=collision.GetComponent<playerController>();
        if(player!=null){
            player.Hit();
        if (Health <5 &&Health >=1 ){
            Health+=1;
        }
            StartCoroutine(OnHit());
        } 
    }

    private IEnumerator OnHit(){
                chase=false;

            yield return  new WaitForSeconds(2.5f);
                    chase=true;

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
}
