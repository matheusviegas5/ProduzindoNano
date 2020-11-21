﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDefeat_Oleo : MonoBehaviour
{
    public Material dissolve;
    public AudioSource somMorte;

    float fade = 1f;
    bool isDissolving;
    public float intensity = 2;
    Color vermelho;
    Color amarelo;

    PlayerMovement playerMovement;
    Animator playerAnimator;

    private void Start()
    {
        float factor = Mathf.Pow(2, intensity);
        vermelho = new Color(Color.red.r * factor, Color.red.g * factor, Color.red.b * factor);
        amarelo = new Color(Color.yellow.r * factor, Color.yellow.g * factor, Color.yellow.b * factor);
        dissolve.SetColor("Color_E187A93B", vermelho);
        dissolve.SetFloat("_Fade", fade);

        playerMovement = GetComponent<PlayerMovement>();
        playerAnimator = GetComponent<Animator>();


    }
    private void Update()
    {
        if (isDissolving)
        {
            fade -= 0.5f * Time.deltaTime;
           if(PlayerLife_Oleo.musicaOleo.pitch > 0) PlayerLife_Oleo.musicaOleo.pitch -= 0.7f * Time.deltaTime;

            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
                SceneManager.LoadScene("Fase_2");


            }

            // Set the property
            dissolve.SetFloat("_Fade", fade);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fungus") || collision.gameObject.CompareTag("SuperFungus"))
        {
            playerAnimator.enabled = false;
            playerMovement.enabled = false;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            isDissolving = true;
            somMorte.Play();

        }
    }
    private void OnDisable()
    {
        dissolve.SetFloat("_Fade", fade);
    }

    public void DefeatedByDirty()
    {
        dissolve.SetColor("Color_E187A93B", amarelo);
        playerAnimator.enabled = false;
        playerMovement.enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        isDissolving = true;
        somMorte.Play();

    }
}
