using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatMoveUp : MonoBehaviour
{
    
   
    
  
    Vector2 floatY;

    public float FloatStrength; // Set strength in Unity

    void Update()
    {
        floatY = transform.position;
        floatY.y = (Mathf.Sin(Time.time+10) * FloatStrength);
        transform.position = floatY;
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag.Equals("Player")){
          col.transform.SetParent(transform);
        }
    }
      void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.tag.Equals("Player")){
            col.transform.SetParent(null);
        }
    }
}
