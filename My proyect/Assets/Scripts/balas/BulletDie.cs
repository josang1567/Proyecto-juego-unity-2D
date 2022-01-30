using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDie : MonoBehaviour
{
    public GameObject diePEffect;
    public float dieTime, damage;
    public AudioClip Sound;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D (Collider2D collision){
    
        GameObject collisionGameObject=collision.gameObject;
       
      if(collisionGameObject.name !="player" && collisionGameObject.tag!="ChaseTrigger" && collisionGameObject.tag!="Life"){
        GruntScript grunt = collision.GetComponent<GruntScript>();
        GranTopo topo = collision.GetComponent<GranTopo>();
        BossController pollo  = collision.GetComponent<BossController>();
        FlyingE bat  = collision.GetComponent<FlyingE>();
        BatCyborg batC  = collision.GetComponent<BatCyborg>();
        Gigadramon giga=collision.GetComponent<Gigadramon>();
        GigaBall b=collision.GetComponent<GigaBall>();
        EnemyController enemy=collision.GetComponent<EnemyController>();
         RanaController rana=collision.GetComponent<RanaController>();
         MinotaurController minos=collision.GetComponent<MinotaurController>();
        if(grunt!=null){
            grunt.Hit();
        }
        if(topo!=null){
            topo.Hit();
        }
        if(pollo!=null){
            pollo.Hit();
        }
        if(bat!=null){
            bat.Hit();
        }
        if(batC!=null){
            batC.Hit();
        }
        if(giga!=null){
            giga.Hit();
        }
        if(b!=null){
            b.Hit();
        }
        if(enemy!=null){
            enemy.Hit();
        }
         if(rana!=null){
            rana.Hit();
        }
        if(minos!=null){
            minos.Hit();
        }
            Die(); 
        } 
        
        
         
    }
    IEnumerator Timer(){
        yield return new WaitForSeconds(dieTime);
        Die();
    }
    void Die(){
        if(diePEffect!=null){
            Instantiate(diePEffect,transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
        //a partir de aqui no escribir porque se destruye el objeto
    }
}
