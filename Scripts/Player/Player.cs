using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Movimentação
    public Rigidbody2D PlayerRb;
    public Transform posicaoPe;
    public float velocidade;
    private float direcao;
    private bool olhandoDireita = true;

    //Double Jump
    private int nroPulos = 1;
    public LayerMask chao;
    public float forcaPulo;
    private bool estaNoChao;
    public float life = 10f;
	public bool invincible = false;

    //Dash
    float doubleTapTime;
    KeyCode lastKeyCode;

    public float dashSpeed;
    private float dashCount;
    public float startDashCount;
    private int side;
    public Animator animator;
    void Start()
    {

    }

    void Update()
    {
        estaNoChao = Physics2D.OverlapCircle(posicaoPe.position,  0.3f, chao);

        direcao = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(direcao));

        PlayerRb.velocity = new Vector2(direcao * velocidade, PlayerRb.velocity.y);

        if((direcao < 0 && olhandoDireita) || (direcao> 0 && !olhandoDireita))
        {
            olhandoDireita = !olhandoDireita;
            transform.Rotate(0f, 180f, 0f);
        }

        //dash
        if(side == 0)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                if(direcao < 0)
                {
                    side = 1;
                }
                else if(direcao > 0)
                {
                    side = 2;
                }
            }
        }
        else
        {
            if(dashCount <= 0)
            {
                side = 0;
                dashCount = startDashCount;
                PlayerRb.velocity = Vector2.zero;
            }
            else
            {
                dashCount -= Time.deltaTime;

                if(side == 1)
                {
                    PlayerRb.velocity = Vector2.left * dashSpeed;
                }
                else if(side == 2)
                {   
                    PlayerRb.velocity = Vector2.right * dashSpeed;
                }
            }
            
        }
        
        CheckInput();
    }

    void CheckInput()
    {
        if(estaNoChao)
        {
            nroPulos = 1;
        }
        if(Input.GetKeyDown(KeyCode.Space) && nroPulos > 0)
        {
            Jump();
        }
    }
     void Jump(){
        animator.SetBool("isJumping", true);
        nroPulos--;
        PlayerRb.velocity = Vector2.up * forcaPulo;
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }
}