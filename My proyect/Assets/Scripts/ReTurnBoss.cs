using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReTurnBoss : MonoBehaviour
{
    private GameObject player;
    public GameObject salida;
        public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        GameObject collisionGameObject=collision.gameObject;
        
        if(collisionGameObject.name=="player"){
      Camera.main.GetComponent<AudioSource>().PlayOneShot(sound);

       player.transform.position=salida.transform.position;

        }
    }
}
