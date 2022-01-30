using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public float startHealth   ;
    private float hp;
    public GameObject diePEffect;
    void Start()
    {
        hp=startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage){
        hp-=damage;
        if(hp<=0f){
            Die();
        }
    }
    void Die(){
        if(diePEffect!=null){
             Instantiate(diePEffect,transform.position, Quaternion.identity);
        }
        
    }
    public float getHealt(){
        return this.hp;
    }
}
