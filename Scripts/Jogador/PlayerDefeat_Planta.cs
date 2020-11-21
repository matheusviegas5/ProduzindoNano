using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefeat_Planta : MonoBehaviour
{
    public Animator[] plantSprites;

    public Material dissolve;
    public SpriteRenderer flor;

    float fade = 1f;
    bool isDissolving;
    public float intensity = 2;
    Color cinza;
    Color vermelho;

    public AudioSource somMorte;

    PlayerMovement playerMovement;
    Animator playerAnimator;
    bool trigger;
    private void Start()
    {
        float factor = Mathf.Pow(2, intensity);
        vermelho = new Color(Color.red.r * factor, Color.red.g * factor, Color.red.b * factor);
        cinza = new Color(Color.gray.r * factor, Color.gray.g * factor, Color.gray.b * factor);
        trigger = false;
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimator = GetComponent<Animator>();
        dissolve.SetFloat("_Fade", fade);
        flor.material. SetFloat("_Fade", fade);

    }
    private void Update()
    {
        if (isDissolving)
        {
            fade -= 0.5f * Time.deltaTime;

            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
                PlayerLife_Planta.PlayerDeath();

            }

            // Set the property
            dissolve.SetFloat("_Fade", fade);
            flor.material.SetFloat("_Fade", fade);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fungus") && !trigger)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

            dissolve.SetColor("Color_E187A93B", vermelho);
            flor.material.SetColor("Color_E187A93B", vermelho);
            DesabilitaMovimentos();
           // StartCoroutine(DeathByFungus()); //player gets purple with script in each sprite
            trigger = true;
        }

        else if (collision.gameObject.CompareTag("BalaoQuebrado") && !trigger)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

            dissolve.SetColor("Color_E187A93B", cinza);
            flor.material.SetColor("Color_E187A93B", cinza);
            DesabilitaMovimentos();

            trigger = true;
        }

        else if (collision.gameObject.CompareTag("VidroQuebrado") && !trigger)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            dissolve.SetColor("Color_E187A93B", cinza);
            flor.material.SetColor("Color_E187A93B", cinza);
            DesabilitaMovimentos();

            trigger = true;
        }
    }
    private void OnDisable()
    {
        dissolve.SetFloat("_Fade", fade);
        flor.material.SetFloat("_Fade", fade);
    }

    void DesabilitaMovimentos()
    {
        somMorte.Play();
        playerMovement.runSpeed = 0;
        playerMovement.enabled = false;
        playerAnimator.enabled = false;
        isDissolving = true;
    }
}
