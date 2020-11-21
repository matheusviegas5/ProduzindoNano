using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotoesUI : MonoBehaviour
{
    public GameObject selecaoFases;
    public void Fase_1()
    {
        ResetaFase3.nanoAtivo = false;
        SceneManager.LoadScene("Fase_1");
    }
    public void Fase_2()
    {
        ResetaFase3.nanoAtivo = false;
        SceneManager.LoadScene("Fase_2");
    }
    public void Fase_3_Farmaco()
    {
        ResetaFase3.nanoAtivo = false;
        SceneManager.LoadScene("Fase_3");
    }
    public void Fase_3_Nano()
    {
        ResetaFase3.nanoAtivo = true;
        SceneManager.LoadScene("Fase_3");
    }
    public void Menu()
    {
        Configuration.isPaused = false;
        AudioListener.pause = false;
        SceneManager.LoadScene("Menu");
    }
    public void SelecaoFases()
    {
        if (!selecaoFases.activeSelf) selecaoFases.SetActive(true);
        else selecaoFases.SetActive(false);
    }
    public void Sair()
    {
        Application.Quit();
    }
}
