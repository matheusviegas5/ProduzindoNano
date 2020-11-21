using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;


public class Hability_Oleo : MonoBehaviour
{
    public ParticleSystem volatilizando;
    public AudioSource volatilizandoSom;

    public SpriteResolver oleoSprite;

    public AudioSource checkPointPequenoSom;
    public AudioSource checkPointGrandeSom;

    public int habilidadeOleo;
    float tempoVolatil = 2;

    CheckPoint_Oleo checkpointOleo;
    Animator animator;
    SpriteRenderer dentroColuna;
    Collider2D colunaCollider;
    Transform colunaTransform;
    bool onColunaPequena;
    bool onColunaGrande;

    // Start is called before the first frame update
    void Start()
    {
        habilidadeOleo = 5;
        checkpointOleo = GetComponent<CheckPoint_Oleo>();
        animator = GetComponent<Animator>();
        oleoSprite.SetCategoryAndLabel("Oleo", "h_5");
        UpdateOleo();
    }

    // Update is called once per frame
    void Update()
    {
        if (habilidadeOleo == 0)
        {
            volatilizandoSom.Stop();
            volatilizando.Stop();
        }
        if (volatilizando.isPlaying) tempoVolatil -= 1 * Time.deltaTime;
        if(tempoVolatil <= 0)
        {
            habilidadeOleo--;
            tempoVolatil = 2;
            UpdateOleo();
        }

        if (Input.GetButtonDown("Fire1") && !Configuration.isPaused)
        {
            if (onColunaPequena)
            {
                checkPointPequenoSom.Play();
                //checkpointOleo.CheckPoinColunaPequena(colunaTransform);
                dentroColuna.color = new Color(0.5f, 0.4f, 0.1f, 1f);
                habilidadeOleo = 5;
                if (PlayerLife_Oleo.playerLife_oleo > 0)
                {
                    PlayerLife_Oleo.playerLife_oleo--;
                    PlayerLife_Oleo.UpdateLives();
                }
                UpdateOleo();
            }
            else if (onColunaGrande)
            {
                checkPointGrandeSom.Play();
                checkpointOleo.CheckPoinColunaGrande(colunaTransform);
                colunaCollider.enabled = false;
                dentroColuna.enabled = false;

            }
            else
            {
                animator.SetBool("Power", true);
                if (habilidadeOleo >= 0)
                {
                    tempoVolatil = 2;
                }       
            }
        }
    }

    private void FixedUpdate()
    {
        animator.SetBool("Power", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColunaPequeno"))
        {
            onColunaPequena = true;
            dentroColuna = collision.GetComponent<SpriteRenderer>();
            colunaTransform = collision.GetComponent<Transform>();
        }
        else if (collision.gameObject.CompareTag("ColunaGrande"))
        {
            onColunaGrande = true;
            dentroColuna = collision.GetComponent<SpriteRenderer>();
            colunaCollider = collision.GetComponent<Collider2D>();
            colunaTransform = collision.GetComponent<Transform>();
        }
        else if (collision.gameObject.CompareTag("Light"))
        {
            if (habilidadeOleo != 0) volatilizando.Play();
            if (habilidadeOleo != 0) volatilizandoSom.Play();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColunaPequeno"))
        {
            onColunaPequena = false;

        }
        else if (collision.gameObject.CompareTag("ColunaGrande"))
        {
            onColunaGrande = false;

        }
        else if (collision.gameObject.CompareTag("Light"))
        {
            volatilizando.Stop();
            volatilizandoSom.Stop();
            tempoVolatil = 2;
        }
    }
    public void UpdateOleo()
    {
        switch (habilidadeOleo)
        {
            case 5:
                oleoSprite.SetCategoryAndLabel("Oleo", "h_5");
                break;
            case 4:
                oleoSprite.SetCategoryAndLabel("Oleo", "h_4");
                break;
            case 3:
                oleoSprite.SetCategoryAndLabel("Oleo", "h_3");
                break;
            case 2:
                oleoSprite.SetCategoryAndLabel("Oleo", "h_2");
                break;
            case 1:
                oleoSprite.SetCategoryAndLabel("Oleo", "h_1");
                break;
            case 0:
                oleoSprite.SetCategoryAndLabel("Oleo", "h_0");
                break;
            default:
                break;
        }
    }
}
