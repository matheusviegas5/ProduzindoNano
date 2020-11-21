using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDirty_Oleo : MonoBehaviour
{
    public ParticleSystem dirtyAbsorption;
    public static float lifeCounter;
    public float publicLifeCounter;
    public bool onSafeZone;
    public static float lifeUpdate = 2;
    public float counterContaminante = 2;

    PlayerDefeat_Oleo playerDefeatOleo;
    private void Start()
    {
        playerDefeatOleo = GetComponent<PlayerDefeat_Oleo>();
        lifeCounter = 30;
    }
    private void Update()
    {
        if (counterContaminante > 0) counterContaminante -= 1 * Time.deltaTime;
        publicLifeCounter = lifeCounter;
        if (!onSafeZone)
        {
            if (!dirtyAbsorption.isPlaying) dirtyAbsorption.Play();
            lifeCounter -= 0.8f * Time.deltaTime;
        }
        else dirtyAbsorption.Stop();

        UpdateDamage();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SafeZone"))
        {
            onSafeZone = true;
        }

        else if (collision.gameObject.CompareTag("Contaminante") && counterContaminante <= 0)
        {
            if (lifeCounter < 10)
            {
                lifeCounter = 0;
            }
            else if (lifeCounter < 20)
            {
                lifeCounter = 10;
            }
            else
            {
                lifeCounter = 20;
            }
            counterContaminante = 2;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Contaminante") && counterContaminante <= 0)
        {
            if (lifeCounter < 10)
            {
                lifeCounter = 0;
            }
            else if (lifeCounter < 20)
            {
                lifeCounter = 10;
            }
            else
            {
                lifeCounter = 20;
            }
            counterContaminante = 2;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SafeZone"))
        {
            onSafeZone = false;
        }
        if (collision.gameObject.CompareTag("Contaminante"))
        {
            counterContaminante = 0;
        }
    }

    void UpdateDamage()
    {
        if (lifeCounter <= 0 && lifeUpdate == 0)
        {
            playerDefeatOleo.DefeatedByDirty();
        }
        if (lifeCounter < 10 && lifeUpdate == 1)
        {
            PlayerLife_Oleo.playerLife_oleo = 1;
            PlayerLife_Oleo.UpdateLives();
        }
        else if (lifeCounter < 20 && lifeUpdate == 2)
        {
            PlayerLife_Oleo.playerLife_oleo = 2;
            PlayerLife_Oleo.UpdateLives();
        }

    }
}
