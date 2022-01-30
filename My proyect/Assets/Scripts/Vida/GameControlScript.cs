using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour
{
    public GameObject vida1,vida2,vida3,vida4,vida5,vida6,vida7,vida8,vida9;
    public static int health;
    public GameObject GameOver;

    void OnEnable()
    {
               

            health=5;
            vida1.gameObject.SetActive(true);
            vida2.gameObject.SetActive(true);
            vida3.gameObject.SetActive(true);
            vida4.gameObject.SetActive(true);
            vida5.gameObject.SetActive(true);
            vida6.gameObject.SetActive(false);
            vida7.gameObject.SetActive(false);
            vida8.gameObject.SetActive(false);
            vida9.gameObject.SetActive(false);
            GameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (health){
            case 0:

            vida1.gameObject.SetActive(false);
            vida2.gameObject.SetActive(false);
            vida3.gameObject.SetActive(false);
            vida4.gameObject.SetActive(false);
            vida5.gameObject.SetActive(false);
            vida6.gameObject.SetActive(false);
            vida7.gameObject.SetActive(false);
            vida8.gameObject.SetActive(false);
            vida9.gameObject.SetActive(false);
            StartCoroutine(EndGame());
           break;
            
            case 1:

            vida1.gameObject.SetActive(true);
            vida2.gameObject.SetActive(false);
            vida3.gameObject.SetActive(false);
            vida4.gameObject.SetActive(false);
            vida5.gameObject.SetActive(false);
            vida6.gameObject.SetActive(false);
            vida7.gameObject.SetActive(false);
            vida8.gameObject.SetActive(false);
            vida9.gameObject.SetActive(false);
            break;
   
           
           
   
            case 2:

            vida1.gameObject.SetActive(true);
            vida2.gameObject.SetActive(true);
            vida3.gameObject.SetActive(false);
            vida4.gameObject.SetActive(false);
            vida5.gameObject.SetActive(false);
            vida6.gameObject.SetActive(false);
            vida7.gameObject.SetActive(false);
            vida8.gameObject.SetActive(false);
            vida9.gameObject.SetActive(false);
            break;
   
            case 3:

            vida1.gameObject.SetActive(true);
            vida2.gameObject.SetActive(true);
            vida3.gameObject.SetActive(true);
            vida4.gameObject.SetActive(false);
            vida5.gameObject.SetActive(false);
            vida6.gameObject.SetActive(false);
            vida7.gameObject.SetActive(false);
            vida8.gameObject.SetActive(false);
            vida9.gameObject.SetActive(false);
            break;
   
            case 4:

            vida1.gameObject.SetActive(true);
            vida2.gameObject.SetActive(true);
            vida3.gameObject.SetActive(true);
            vida4.gameObject.SetActive(true);
            vida5.gameObject.SetActive(false);
            vida6.gameObject.SetActive(false);
            vida7.gameObject.SetActive(false);
            vida8.gameObject.SetActive(false);
            vida9.gameObject.SetActive(false);
            break;
   
            case 5:

            vida1.gameObject.SetActive(true);
            vida2.gameObject.SetActive(true);
            vida3.gameObject.SetActive(true);
            vida4.gameObject.SetActive(true);
            vida5.gameObject.SetActive(true);
            vida6.gameObject.SetActive(false);
            vida7.gameObject.SetActive(false);
            vida8.gameObject.SetActive(false);
            vida9.gameObject.SetActive(false);
            break;
   
            case 6:

            vida1.gameObject.SetActive(true);
            vida2.gameObject.SetActive(true);
            vida3.gameObject.SetActive(true);
            vida4.gameObject.SetActive(true);
            vida5.gameObject.SetActive(true);
            vida6.gameObject.SetActive(true);
            vida7.gameObject.SetActive(false);
            vida8.gameObject.SetActive(false);
            vida9.gameObject.SetActive(false);
            break;
   
            case 7:

            vida1.gameObject.SetActive(true);
            vida2.gameObject.SetActive(true);
            vida3.gameObject.SetActive(true);
            vida4.gameObject.SetActive(true);
            vida5.gameObject.SetActive(true);
            vida6.gameObject.SetActive(true);
            vida7.gameObject.SetActive(true);
            vida8.gameObject.SetActive(false);
            vida9.gameObject.SetActive(false);
            break;
   
            case 8:

            vida1.gameObject.SetActive(true);
            vida2.gameObject.SetActive(true);
            vida3.gameObject.SetActive(true);
            vida4.gameObject.SetActive(true);
            vida5.gameObject.SetActive(true);
            vida6.gameObject.SetActive(true);
            vida7.gameObject.SetActive(true);
            vida8.gameObject.SetActive(true);
            vida9.gameObject.SetActive(false);
            break;
   
            case 9:

            vida1.gameObject.SetActive(true);
            vida2.gameObject.SetActive(true);
            vida3.gameObject.SetActive(true);
            vida4.gameObject.SetActive(true);
            vida5.gameObject.SetActive(true);
            vida6.gameObject.SetActive(true);
            vida7.gameObject.SetActive(true);
            vida8.gameObject.SetActive(true);
            vida9.gameObject.SetActive(true);
            break;
   
            default:
            break;
        }
    }

   IEnumerator EndGame(){
      
       yield return new WaitForSeconds(0.11f);
        GameOver.gameObject.SetActive(true);
            Time.timeScale=0;
   }
}
