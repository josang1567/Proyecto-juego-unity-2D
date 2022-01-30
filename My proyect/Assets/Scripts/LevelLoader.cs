using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
  public int iLevelToLoad;
  public string sLevelToLoad;
  public bool useIntegerToLoadLevel=false;
  public bool IsEnable;
  MinotaurController mino ;
 playerController player;

    void Start()
    {
        IsEnable=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(mino.isAlive==false){
            IsEnable=true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
       
      // if(IsEnable==true){
        GameObject collisionGameObject=collision.gameObject;
        Debug.Log(collisionGameObject.name);
        if(collisionGameObject.name=="player"){
      

            LoadScene();
        }
      // }
       
    }
    void LoadScene(){
        if(useIntegerToLoadLevel){
            
            SceneManager.LoadScene(iLevelToLoad);
        }else{
            

            SceneManager.LoadScene(sLevelToLoad);
           
           
        }
    }
}
