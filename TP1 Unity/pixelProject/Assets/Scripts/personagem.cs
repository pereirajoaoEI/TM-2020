using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personagem : MonoBehaviour
{

    public float speed;
    public float forcaSalto;
    private Rigidbody2D rigid;
    private Animator animacao;
    public bool jump;
    public bool doubleJump;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();
    }

   
    void Update()
    {
        Movimento();
        Salto();

    }

    void Movimento()
    {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movimento * Time.deltaTime * speed;

        if (Input.GetAxis("Horizontal") > 0f)
        {

            animacao.SetBool("correr", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        
        if (Input.GetAxis("Horizontal") < 0f)
        {

            animacao.SetBool("correr", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Input.GetAxis("Horizontal") == 0f)
        {

            animacao.SetBool("correr", false );
        }
    }

    void Salto()
    {
        if (Input.GetButtonDown("Jump") )
        {
            if(jump == false)
            {
                rigid.AddForce(new Vector2(0f, forcaSalto), ForceMode2D.Impulse);
                doubleJump = true;
                animacao.SetBool("salto", true);
            }
            else
            {
                if(doubleJump)
                 {
                    rigid.AddForce(new Vector2(0f, forcaSalto *2f), ForceMode2D.Impulse);
                    doubleJump = false;
                }

            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            jump = false;
            animacao.SetBool("salto", false);
        }

        if(collision.gameObject.tag == "saw"){

       controlo.contr.ShowGameOver();
        Destroy(gameObject);
   // Debug.Log("tocou");
        }

        if(collision.gameObject.tag == "espinho")
        {
            controlo.contr.ShowGameOver();
            Destroy(gameObject);
            //Debug.Log("Tocou no Espinho!");
        }
    }

    
    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 8)
        {
            jump = true;
        }

    }
}
