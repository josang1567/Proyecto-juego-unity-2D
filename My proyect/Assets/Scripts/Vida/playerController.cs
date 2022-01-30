using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveDirection=0;
    private bool facingRight=true;
    private Animator anim;
    public bool isAttacking;
    public float maxSpeed=4;
    public float jumpForce=7;
    public bool isGrounded;
    public  LayerMask layerGround;
    public GameObject foot;
    public AudioClip andar;
    public AudioClip saltar;
        public AudioClip herido;

    private AudioSource audioAndar;
        private AudioClip Muerte;

    public float radius=0.2f;
    public bool isAlive;
    //gruntJhon
    public int Health=5;
    public int MaxHealth;
    void Start()
    {
        Debug.Log("start");
        DontDestroyOnLoad(gameObject);
        isAttacking=false;
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        audioAndar=GetComponent<AudioSource>();
      
        isAlive=true;
    }

    // Update is called once per frame
    void Update()
    {
        //detectar los botones
        if(Input.GetKey(KeyCode.D)){
            //andar.0
           
            moveDirection=1;
            if(!audioAndar.isPlaying && isGrounded==true)
                audioAndar.Play();

        }else if(Input.GetKey(KeyCode.A)){
             
              if(!audioAndar.isPlaying && isGrounded==true)
                audioAndar.Play();
            moveDirection=-1;
            
        }else{
            moveDirection=0;
            if(audioAndar.isPlaying)
                audioAndar.Stop();
        }
     
        if(moveDirection!=0){
            if(moveDirection>0 && !facingRight){
                //girate para la derecha
                transform.localScale=new Vector3(1,1,1);
                facingRight=true;
            }
            if(moveDirection<0 && facingRight){
                //girate para la izquierda
                transform.localScale=new Vector3(-1,1,1);
                facingRight=false;
            }   
        }
         if(Input.GetKeyDown(KeyCode.X)){
            if(maxSpeed==4){
                 maxSpeed=6;
            }else if(maxSpeed==6){
                 maxSpeed=4;
            }

            
        }
        if(Input.GetButtonDown("Fire1")){
            StartCoroutine(Shoot());
           
        }
        if(Input.GetKeyDown(KeyCode.E)){
            StartCoroutine(Shoot());
           
        }
        if(Input.GetKeyDown (KeyCode.W) && isGrounded){
              Camera.main.GetComponent<AudioSource>().PlayOneShot(saltar);
            rb.velocity=new Vector2(rb.velocity.x,jumpForce);
        }
    }

    void FixedUpdate(){
        //isGrounded???
        isGrounded=Physics2D.OverlapCircle(foot.transform.position, 0.2f,layerGround);


        //aplicar las fuerzas
        Vector2 newSpeed= new Vector2(moveDirection*maxSpeed,rb.velocity.y);
        rb.velocity=newSpeed;
        anim.SetFloat("speed",Mathf.Abs(rb.velocity.x));
        anim.SetBool("isgrounded",isGrounded);
        anim.SetBool("isAttacking",isAttacking);
        anim.SetBool("IsAlive",isAlive);
        if(isAttacking==true){
            
            isAttacking=false;
        }
       
    }
    IEnumerator Shoot(){
        isAttacking=true;
        
        yield return new WaitForSeconds(0.5f);
        isAttacking=false;
    }
    private void OnEnable(){
       
        FindStartPos();
    }
    private void OnLevelWasLoaded(){
       
        FindStartPos();
    }
    public void FindStartPos(){
      
        transform.position=GameObject.FindWithTag("StartPos").transform.position;
        Debug.Log("Posicion Jugador: "+this.transform.position);
    }

    //gruntjhom
    public void Hit()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(herido);
        Health -= 1;
        GameControlScript.health-=1;
        if (Health <= 0){
           death();
            
        } 
    }

    

    public void Cura(int cura){
        if(Health<MaxHealth){
            Health+=cura;
        }
        if(Health>MaxHealth){
            Health=MaxHealth;
        }
        
    }
    public void Mejora(int cura){
        
        MaxHealth+=cura;
        Cura(cura*2);
        
    }
    public void death(){
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Muerte);
        Destroy(gameObject);
    }
}
