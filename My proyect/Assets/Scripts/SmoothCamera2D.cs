using UnityEngine;
 using System.Collections;
 
 public class SmoothCamera2D : MonoBehaviour {
     
     public float dampTime = 0.15f;
     private Vector3 velocity = Vector3.zero;
     private GameObject target;
 
     // Update is called once per frame
     void Start(){
        target=GameObject.FindGameObjectWithTag("Player");
     }
     void Update () 
     {
         if (target)
         {
             Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.transform.position);
             Vector3 delta = target.transform.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
             Vector3 destination = transform.position + delta;
             transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
         }
        
     }
 }
