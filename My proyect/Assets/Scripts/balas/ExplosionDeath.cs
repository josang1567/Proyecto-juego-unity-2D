using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDeath : MonoBehaviour
{
       public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Die(){
      
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sound);
        Destroy(gameObject);
        //a partir de aqui no escribir porque se destruye el objeto
    }
}
