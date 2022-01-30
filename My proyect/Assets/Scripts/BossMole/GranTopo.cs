using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranTopo : MonoBehaviour
{
  
    
   public GameObject BulletPrefab;
    private GameObject player;//Jugador
    private float LastShoot;
    public int Health=15;  
    public GameObject diePEffect;
     public Transform shootPos;
    public Transform shootPos2;
    public Transform shootPos3;
     public Transform shootPosH;
    public Transform shootPosH2;
    public Transform shootPosH3;
    private Animator anim;
public AudioClip impacto;
    private bool isAlive;

    void Start()
    {
        isAlive=true;
         anim=GetComponent<Animator>();
         player=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
         if(player==null)return;
         Vector3 direction = player.transform.position-transform.position;
        float d= Mathf.Abs(direction.x);
       
           float distance= Mathf.Abs(player.transform.position.x-transform.position.x);
        if(d<10.0f  && Time.time>LastShoot+1.25f){
            StartCoroutine(Shoot());
           
            LastShoot=Time.time+3;
        }
        
    }
    

      IEnumerator Shoot(){
     
      
     
      Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
           


      //balas verticales
      GameObject bullet= Instantiate(BulletPrefab,shootPos.position,Quaternion.identity);
      GameObject bullet2= Instantiate(BulletPrefab,shootPos2.position,Quaternion.identity);
      GameObject bullet3= Instantiate(BulletPrefab,shootPos3.position,Quaternion.identity);
      
      bullet.GetComponent<Piedra>().SetDirection(direction);
            yield return new WaitForSeconds(0.5f);
      bullet2.GetComponent<Piedra>().SetDirection(direction);
           yield return new WaitForSeconds(0.5f);
      bullet3.GetComponent<Piedra>().SetDirection(direction);


         yield return new WaitForSeconds(1.5f);
       

 StartCoroutine(Shoot2());


    }
    IEnumerator Shoot2(){
        //balas horizontales
    Vector3 direction2 = new Vector3(transform.localScale.x, player.transform.position.x, 0.0f);


    GameObject bulletH= Instantiate(BulletPrefab,shootPosH.position,Quaternion.identity);
    GameObject bulletH2= Instantiate(BulletPrefab,shootPosH2.position,Quaternion.identity);
    GameObject bulletH3= Instantiate(BulletPrefab,shootPosH3.position,Quaternion.identity);

    bulletH.GetComponent<Piedra>().SetDirection(direction2);
            yield return new WaitForSeconds(0.5f);
    bulletH2.GetComponent<Piedra>().SetDirection(direction2);
           yield return new WaitForSeconds(0.5f);
    bulletH3.GetComponent<Piedra>().SetDirection(direction2);
    }
    public void Hit()
    {
        Health -= 2;
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
    }
}
