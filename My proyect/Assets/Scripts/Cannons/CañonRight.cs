using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CañonRight : MonoBehaviour
{
    
    public GameObject BulletPrefab;
    private GameObject player;//Jugador
    private float LastShoot;
    public GameObject Effect;
    public Transform shootPos;
    public AudioClip Sound;
        public float rango;

    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
         if(player==null)return;
         Vector3 direction = player.transform.position-transform.position;
      
        if(direction.x>=0.0f){
          transform.localScale=new Vector3(1.0f,1.0f,1.0f);
        }
           float distance= Mathf.Abs(player.transform.position.x-transform.position.x);
        if(distance<rango && Time.time>LastShoot+1.25f){
            Shoot();
            LastShoot=Time.time+2;
        }
    }
    

      private void Shoot(){
     
      Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
       Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
      Instantiate(Effect,shootPos.position, Quaternion.identity);
       GameObject bullet= Instantiate(BulletPrefab,shootPos.position,Quaternion.identity);
       bullet.GetComponent<BulletScript>().SetDirection(direction);
            
    }
}
