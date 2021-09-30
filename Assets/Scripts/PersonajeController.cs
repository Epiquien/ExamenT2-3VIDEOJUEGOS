using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb;

    private const int Idle = 0;
    private const int Run = 1;
    private const int Slide = 2;
    private const int Climb = 3;
    private const int Glide = 4;
    private const int Dead = 5;
    
    public float velocityX = 7; 
    //public float jumpForce = 30;
  //  private bool estaSaltando = false;
    private const int PISO = 7;

    private float vertical;
    private float speed = 7f;
    private bool isLadder;
    private bool isClimbing;
    
    
    public GameObject rightBullet;
    public GameObject leftBullet;
    
    private GameController _game;
    
    private const int ENEMIGO = 10;
    
    // Start is called before the first frame update ////////////////////////////////////
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
        _game = FindObjectOfType<GameController>();
    }

    // Update is called once per frame ////////////////////////////////////////////
    void Update()
    {
        CambiarAnimacion(Idle);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false;
            CambiarAnimacion(Run);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(- velocityX, rb.velocity.y);
            sr.flipX = true;
            CambiarAnimacion(Run);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.C))
        {
            CambiarAnimacion(Slide);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            CambiarAnimacion(Climb);
            Debug.Log("presionando tecla arriba");
        }
        vertical = Input.GetAxis("Vertical");
       
        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
           
        }


        if (Input.GetKeyUp(KeyCode.X))
        {
            
                var bullet = sr.flipX ? leftBullet : rightBullet;
                var position = new Vector2(transform.position.x, transform.position.y);
                var rotation = rightBullet.transform.rotation;
                Instantiate(bullet, position, rotation);
               
            
            
        }




    }

    private void FixedUpdate()
    {
       
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
           
        }
        else
        {
            rb.gravityScale = 4f;
        }
    }


  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }

       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == ENEMIGO)
        {
            _game.DisminuirVidas(1);
            Destroy(other.gameObject);
            
            
        }
    }


    private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }
}
