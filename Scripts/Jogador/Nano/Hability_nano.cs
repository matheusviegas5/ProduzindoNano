using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hability_nano : MonoBehaviour
{
    public float superiorLimit;
    public float inferiorLimit;
    public ParticleSystem habilidadeNano;
    public AudioSource habilidadeNanoSom;

    public GameObject alvo;

    CharacterController2D controller;
    Transform jogadorTransform;
    PlayerMovement movimentoJogador;
    Animator animator;
    public GameObject bone4;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        jogadorTransform = GetComponent<Transform>();
        movimentoJogador = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && (!animator.GetBool("IsJumping") && !animator.GetBool("IsFalling")) && !Configuration.isPaused)
        {
           if(!alvo.activeSelf) alvo.SetActive(true);
            controller.rb.velocity = new Vector2 (0,0);
            //controller.Move(0, false, animator.GetBool("IsJumping"));
            animator.SetBool("Power", true);
            movimentoJogador.enabled = false;
            Aiming();
        }
        else if (Input.GetButtonUp("Fire1") && (!animator.GetBool("IsJumping") && !animator.GetBool("IsFalling")))
        {
            StartCoroutine(Dispara());
        }
    }

    IEnumerator Dispara()
    {
        habilidadeNanoSom.Play();
        habilidadeNano.Play();
        animator.SetBool("Power", false);
        movimentoJogador.enabled = true;
        yield return new WaitForSeconds(0.1f);
        bone4.transform.rotation = new Quaternion(0, 0, 0, 1);
        alvo.SetActive(false);
    }
    void Aiming()
    {
        if (IsLookingRight())
        {
            if (Input.GetAxisRaw("Vertical") > 0 && bone4.transform.rotation.z <= superiorLimit)
            {
                bone4.transform.Rotate(0, 0, 1f);
            }
            else if (Input.GetAxisRaw("Vertical") < 0 && bone4.transform.rotation.z >= inferiorLimit)

            {
                bone4.transform.Rotate(0, 0, -1f);
            }
        }
        else
        {
            if (Input.GetAxisRaw("Vertical") > 0 && bone4.transform.rotation.z >= -superiorLimit)
            {
                bone4.transform.Rotate(0, 0, 1f);
            }
            else if (Input.GetAxisRaw("Vertical") < 0 && bone4.transform.rotation.z <= -inferiorLimit)

            {
                bone4.transform.Rotate(0, 0, -1f);
            }
        }
    }

    bool IsLookingRight()
    {
        if (jogadorTransform.localScale.x > 0)
        {
            return true;
        }
        else return false;
    }
}
