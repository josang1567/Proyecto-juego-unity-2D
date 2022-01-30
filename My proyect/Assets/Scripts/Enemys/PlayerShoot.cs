using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float shootSpeed, shootTimer;
    private bool isShooting;
    public Transform shootPos;
    public Transform shootPos2;

    public GameObject bullet;
    public
    // Start is called before the first frame update
    void Start()
    {
        isShooting=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")&& !isShooting){
            //Shoot;
            StartCoroutine(Shoot());
        }
        if(Input.GetKeyDown(KeyCode.E)&& !isShooting){
            //Shoot2;
            StartCoroutine(Shoot2());
        }
    }
      int direction(){
            if (transform.localScale.x<0f){
                return-1;
            }else{
                return+1;
            }
        }
    IEnumerator Shoot(){
      
        isShooting=true;
        GameObject newBullet= Instantiate(bullet,shootPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity= new Vector2(shootSpeed*direction()*Time.fixedDeltaTime,0f);
        newBullet.transform.localScale= new Vector2(newBullet.transform.localScale.x*direction(), newBullet.transform.localScale.y);
        yield return new WaitForSeconds(shootTimer);
        isShooting=false;
    }
    IEnumerator Shoot2(){
       
        isShooting=true;
        GameObject newBullet= Instantiate(bullet,shootPos2.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().constraints=RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        newBullet.GetComponent<Rigidbody2D>().velocity= new Vector2(0f,shootSpeed*Time.deltaTime);
        newBullet.transform.rotation=Quaternion.Euler(0,0,90);
       //  rotatio 90 z newBullet.transform.localScale= new Vector2(newBullet.transform.localScale.x, newBullet.transform.localScale.y*direction());
        yield return new WaitForSeconds(shootTimer);
        isShooting=false;
    }
}
