using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float dieTime, damage;
    public GameObject diePEffect;
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Timer(){
        yield return new WaitForSeconds(dieTime);
        die();
    }
   private void OnTriggerEnter2D(Collider2D collision){
     
        GameObject collisionGameObject=collision.gameObject;
      if(collisionGameObject.name !="player"){
           
            die();
        } 
    }
    void die(){
        if(diePEffect!=null){
            Instantiate(diePEffect,transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
