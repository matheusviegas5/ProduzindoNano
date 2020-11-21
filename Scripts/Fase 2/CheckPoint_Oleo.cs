using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint_Oleo : MonoBehaviour
{
    public static Vector3 spawnPoint = new Vector3(0, 0, 0);
    static SpriteRenderer dentroColuna;
    private void Start()
    {
        try
        {
            dentroColuna.enabled = false;
        }
        catch (System.Exception)
        {
        }
        transform.position = spawnPoint;
    }
    public void CheckPoinColunaPequena(Transform coluna)
    {
        //recupera habilidade
        dentroColuna = coluna.gameObject.GetComponent<SpriteRenderer>();
        if (dentroColuna.color == new Color(0.5f, 0.4f, 0.1f, 1f))
        {
            if (PlayerLife_Oleo.playerLife_oleo > 1) PlayerLife_Oleo.playerLife_oleo--; //diminui um de vida
        }
        spawnPoint = coluna.position;
    }
    public void CheckPoinColunaGrande(Transform coluna)
    {
        dentroColuna = coluna.gameObject.GetComponent<SpriteRenderer>();
        PlayerLife_Oleo.playerLife_oleo = 3;
        PlayerLife_Oleo.UpdateLives();
        spawnPoint = coluna.position;
    }
}
