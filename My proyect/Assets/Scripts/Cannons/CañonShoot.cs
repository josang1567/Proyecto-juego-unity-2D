using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CañonShoot : MonoBehaviour
{
   
    public GameObject BulletPrefab;
    public GameObject Jhon;//Jugador
    private float LastShoot;
    public GameObject Effect;
    public AudioClip Sound;
        public float rango;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Jhon==null)return;
         Vector3 direction = Jhon.transform.position-transform.position;
      
        if(direction.x>=0.0f){
          transform.localScale=new Vector3(1.0f,1.0f,1.0f);
        }else{
             transform.localScale=new Vector3(-1.0f,1.0f,1.0f);
        }
           float distance= Mathf.Abs(Jhon.transform.position.x-transform.position.x);
        if(distance<rango  && Time.time>LastShoot+1.25f){
            Shoot();
            LastShoot=Time.time;
        }
    }
    

      private void Shoot(){
     
      Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
       Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        Instantiate(Effect,transform.position+direction*1.5f, Quaternion.identity);
       GameObject bullet= Instantiate(BulletPrefab,transform.position+direction*1.5f,Quaternion.identity);
       bullet.GetComponent<BulletScript>().SetDirection(direction);
            
    }
}
