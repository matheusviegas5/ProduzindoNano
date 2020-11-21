using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.SceneManagement;

public class PlayerLife_Planta : MonoBehaviour
{
    public static int playerLife = 3;

    public static List<SpriteResolver> spriteResolvers = new List<SpriteResolver>();
    void Start()
    {
        foreach (var resolver in FindObjectsOfType<SpriteResolver>())
        {
            spriteResolvers.Add(resolver);
        }

        UpdateLives();
    }

    public static void PlayerDeath()
    {
        playerLife--;
        if (playerLife <= 0)
        {
            playerLife = 3;
            CheckPoint.initialPoint = new Vector3(0, 0, 0);
            SceneManager.LoadScene("Menu");
        }
        else SceneManager.LoadScene("Fase_1");
    }

    public static void UpdateLives()
    {
        if (playerLife == 3)
        {
            foreach (var resolver in FindObjectsOfType<SpriteResolver>())
            {
                resolver.SetCategoryAndLabel(resolver.GetCategory(), "planta_3");
            }
        }

        if (playerLife == 2)
        {
            foreach (var resolver in FindObjectsOfType<SpriteResolver>())
            {
                resolver.SetCategoryAndLabel(resolver.GetCategory(), "planta_2");
            }
        }

        if (playerLife == 1)
        {
            foreach (var resolver in FindObjectsOfType<SpriteResolver>())
            {
                resolver.SetCategoryAndLabel(resolver.GetCategory(), "planta_1");
            }
        }
    }
}
