using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.SceneManagement;


public class PlayerLife_Oleo : MonoBehaviour
{
    public static int playerLife_oleo = 3;
    public static AudioSource musicaOleo;

    public static List<SpriteResolver> spriteResolvers = new List<SpriteResolver>();
    void Start()
    {
        musicaOleo = GameObject.Find("MusicaOleo").GetComponent<AudioSource>();
        playerLife_oleo = 3;
        foreach (var resolver in FindObjectsOfType<SpriteResolver>())
        {
            spriteResolvers.Add(resolver);
        }

        UpdateLives();
    }

    //public static void PlayerDeath()
    //{
    //        SceneManager.LoadScene("Fase_2");      
    //}

    public static void UpdateLives()
    {
        if (playerLife_oleo == 3)
        {
            musicaOleo.pitch = 1;
            OnDirty_Oleo.lifeUpdate = 2;
            OnDirty_Oleo.lifeCounter = 30;
            foreach (var resolver in FindObjectsOfType<SpriteResolver>())
            {
                resolver.SetCategoryAndLabel(resolver.GetCategory(), "3");
            }
        }

        if (playerLife_oleo == 2)
        {
            musicaOleo.pitch = 0.9f;
            OnDirty_Oleo.lifeCounter = 20;
            OnDirty_Oleo.lifeUpdate = 1;
            foreach (var resolver in FindObjectsOfType<SpriteResolver>())
            {
                resolver.SetCategoryAndLabel(resolver.GetCategory(), "2");
            }
        }

        if (playerLife_oleo == 1)
        {
            musicaOleo.pitch = 0.8f;
            OnDirty_Oleo.lifeCounter = 10;
            OnDirty_Oleo.lifeUpdate = 0;
            foreach (var resolver in FindObjectsOfType<SpriteResolver>())
            {
                resolver.SetCategoryAndLabel(resolver.GetCategory(), "1");
            }
        }
    }
}
